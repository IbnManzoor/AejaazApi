using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMModels;
using AMAPI;
using System.Data.SqlClient;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArabicWordsController : ControllerBase
    {
        private ILogger _logger;
        private IWordsService _service;
        private IOptions<MySettings> _options;

        public ArabicWordsController(ILogger<ArabicWordsController> logger, IWordsService service, IOptions<MySettings> options)
        {
            _logger = logger;
            _service = service;

            _options = options;
        }

        [HttpGet("AllWords")]
        public IActionResult AllWords()
        {
            var constr = GetSqlConnectionString();
            var data = _service.GetWords(constr);

            return Ok(data);
        }

        [HttpGet("AllWordsPaginated")]
        public IActionResult AllWordsPaginated(Int64 page, Int64 Size)
        {
            var constr = GetSqlConnectionString();
            var data = _service.GetWordsPaginated(page, Size, constr);

            return Ok(data);
        }

        [Route("AllWords/{id}")]
        public IActionResult AllWords(Int64 id)
        {
            var constr = GetSqlConnectionString();
            var data = _service.GetWords(constr).FirstOrDefault(m => m.ID == id);
            return Ok(data);
        }

        [Route("AllWordsByPageNo")]
        public IActionResult AllWordsByPageNo(Int64 id, Int64 cno)
        {
            var constr = GetSqlConnectionString();
            var data = _service.GetWordByPageNo(id, cno, constr);
            return Ok(data);
        }

        [HttpPost]
        [Route("AddWord")]
        public IActionResult AddWord([FromBody] Words word)
        {
            var constr = GetSqlConnectionString();
            var data = _service.AddWord(word, constr);
            return Ok(data);
        }

        [HttpGet]
        [Route("TodaysWord")]
        public IActionResult TodaysWord(Int64 PageNo, Int64 ColNo)
        {
            var constr = GetSqlConnectionString();
            var data = _service.TodaysRandomWord(PageNo, ColNo, constr);
            return Ok(data);
        }

        [HttpGet]
        [Route("ToBeSeen")]
        public IActionResult ToBeSeen(Int64 PageNo, Int64 ColNo)
        {
            var constr = GetSqlConnectionString();
            var data = _service.ToBeSeen(PageNo, ColNo, constr);
            return Ok(data);
        }

        [HttpPost]
        [Route("EditWord/{id}")]
        public IActionResult EditWord([FromBody] Words word)
        {
            var constr = GetSqlConnectionString();
            var data = _service.UpdateWord(word, constr);
            return Ok(data);
        }

        [HttpDelete]
        [Route("DeleteWord/{id}")]
        public IActionResult DeleteWord(Int64 id)
        {
            var constr = GetSqlConnectionString();
            var data = _service.DeleteWord(id, constr);
            return Ok(data);
        }

        [HttpGet]
        [Route("AllPageNos")]
        public IActionResult AllPageNos()
        {
            var constr = GetSqlConnectionString();
            var data = _service.GetPageNos(constr);

            return Ok(data);
        }
        [HttpGet]
        [Route("AllColNos")]
        public IActionResult AllColNos()
        {
            var constr = GetSqlConnectionString();
            var data = _service.GetColNos(constr);

            return Ok(data);
        }

        [HttpGet]
        [Route("ResetSeen")]
        public IActionResult ResetSeenWords()
        {
            var constr = GetSqlConnectionString();
            var data = _service.ResetSeen(constr);

            return Ok(data);
        }

        [HttpGet]
        public string GET()
        {
            var abc = _options.Value.DBConnection;
            return abc;
        }

        public string GetSqlConnectionString()
        {
            return _options.Value.DBConnection;
        }
    }
}
