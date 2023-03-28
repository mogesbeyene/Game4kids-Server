
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Games4Kids
{
    [Route("api/match")]
    [ApiController]
    [EnableCors("Application")]

    public class MatchRecordController : ControllerBase
    {
        private readonly MatchRecordLogic matchRecordLogic;


        public MatchRecordController(MatchRecordLogic logic)
        {
            matchRecordLogic = logic;
        }

        [HttpGet]
        [Route("GetAllMatchRecord/{id}")]
        public IActionResult GetAllMatchRecord(int id)
        {
            try
            {
               List<MatchRecordViewModel> matchRecords = matchRecordLogic.GetAllMatchRecord(id);
                if (matchRecords == null)
                    return NotFound($"id {id} not found");

                return Ok(matchRecords);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelper.GetExceptionMessage(ex));
            }
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddMatchRecord([FromBody] MatchRecordViewModel matchRecordViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ErrorHelper.ExtractErrors(ModelState));

                MatchRecordViewModel addedMatchRecord = matchRecordLogic.AddMatchRecord(matchRecordViewModel);
                return Created("api/match" + addedMatchRecord.UserID, addedMatchRecord);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelper.GetExceptionMessage(ex));
            }
        }

        


        [HttpPost]
        [Route("GetSumPointsByGameType")]
        public IActionResult GetSumPointsByGameType([FromBody] GetRequestMatchRecord getRequestMatchRecord)
        {
            try
            {
                //GameType gameType = id == 1 ? GameType.FourInARow : GameType.TicTac; 
                //string sumOfGames = matchRecordLogic.GetSumPointsByGameType(GameType.TicTac, getRequestMatchRecord.UserID);
                //if (sumOfGames == null)
                //    return NotFound($"sumOfGames Not Found");

                //return Ok(sumOfGames);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelper.GetExceptionMessage(ex));
            }
        }


    }
}
