
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;



namespace Games4Kids
{
    [Route("api/settings")]
    [ApiController]
    [EnableCors("Application")]

    public class GameSettingController : ControllerBase
    {
        private readonly GameSettingLogic gameSettingLogic;


        public GameSettingController(GameSettingLogic logic)
        {
            gameSettingLogic = logic;
        }

        [HttpGet]
        [Route("GetGameSettingByPlayer/{playerID}")]
        public IActionResult GetGameSettingByPlayer(int playerID)
        {
            try
            {
                GameSettingViewModel gameSetting = gameSettingLogic.GetGameSetting(playerID);
                if (gameSetting == null)
                    return NotFound($"player settings id {playerID} not found");

                return Ok(gameSetting);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelper.GetExceptionMessage(ex));
            }
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddGameSetting([FromBody] GameSettingViewModel gameSettingViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ErrorHelper.ExtractErrors(ModelState));

                GameSettingViewModel addedGameSetting = gameSettingLogic.AddDefualtGameSetting(gameSettingViewModel);
                return Created("api/settings" + addedGameSetting.UserID, addedGameSetting);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelper.GetExceptionMessage(ex));
            }
        }


        [HttpPatch("UpdateLockTimeSettings/{userID:int}")]
        [Route("UpdateLockTimeSettings/{userID}")]
        public IActionResult UpdateLockTimeSettings(int userID, [FromBody] GameSettingViewModel gameSettingViewModel)
        {
            try
            {
                GameSettingViewModel gameSetting = gameSettingLogic.UpdateLockTime(userID, gameSettingViewModel);

                return Ok(gameSetting);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelper.GetExceptionMessage(ex));
            }
        }


        [HttpPatch("UpdateSettingsProps/{userID:int}")]
        [Route("UpdateSettingsProps/{userID}")]
        public IActionResult UpdateSettingsProps(int userID, [FromBody] GameSettingViewModel gameSettingViewModel)
        {
            try
            {
                GameSettingViewModel gameSetting = gameSettingLogic.UpdateSettingsProps(userID, gameSettingViewModel);

                return Ok(gameSetting);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorHelper.GetExceptionMessage(ex));
            }
        }


    }
}
