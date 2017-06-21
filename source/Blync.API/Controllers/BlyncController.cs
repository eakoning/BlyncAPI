using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

using Blynclight;

namespace API.Controllers
{
    public class BlyncController : ApiController
    {
        private const string slackCommandText = "text";

        private readonly BlynclightController _blynclightController;

        private readonly int _deviceId = 0;

        public BlyncController() : this(0)
        {
            _blynclightController = new BlynclightController();
            _blynclightController.InitBlyncDevices();
        }

        public BlyncController(int deviceId)
        {
            _deviceId = deviceId;
        }

        //[HttpGet]
        //public IEnumerable<byte> Get()
        //{
        //    int result = _blynclightController.InitBlyncDevices();

        //    //return Enumerable.Range(0, result).Select(deviceId => _blynclightController.GetDeviceType(deviceId)).ToArray();
        //}

        //public byte Get2(int deviceId)
        //{
        //    return _blynclightController.GetDeviceType(deviceId);
        //}

        [HttpPost]
        [Route("api/Blync/On/{deviceId}/{red}/{green}/{blue}")]
        public IHttpActionResult TurnRGBLedOn([FromBody] int deviceId, byte red, byte green, byte blue)
        {
            if (_blynclightController.TurnRGBLedOn(deviceId, red, green, blue))
            {
                return Ok();
            }

            return NotFound();
        }

        //[HttpPost]
        //[Route("api/Blync/Flash/{deviceId}")]
        //public async Task<IHttpActionResult> Flash(int deviceId)
        //{
        //    var parameters = await GetRequestParameters();
        //    string flashCommand = parameters?[slackCommandText];

        //    FlashArguments arguments = FlashCommandParser.Parse(flashCommand);

        //    if (_blyncLightHelper.Flash(deviceId, arguments))
        //    {
        //        return Ok();
        //    }

        //    return BadRequest($"The specified command '{flashCommand}' is invalid");
        //}

        //[HttpPost]
        //[Route("api/Blync/SetColor/{deviceId}")]
        //public async Task<IHttpActionResult> SetColor(int deviceId)
        //{
        //    var parameters = await GetRequestParameters();
        //    string color = parameters?[slackCommandText];

        //    IHttpActionResult result;

        //    if (_blyncLightHelper.SetColor(deviceId, color))
        //    {
        //        result = Ok();
        //    }
        //    else
        //    {
        //        result = BadRequest($"The specified color '{color}' is invalid");
        //    }

        //    return result;
        //}

        [HttpPost]
        [Route("api/Blync/Off/{deviceId}")]
        public void Reset(int deviceId)
        {
            _blynclightController.TurnLedOff(deviceId);
        }

        //[HttpPost]
        //[Route("api/Blync/Sine/{deviceId}")]
        //public void Sine(int deviceId)
        //{
        //    _blyncLightHelper.SetColor(0, Color.Black);

        //    for (int j = 0; j < 255; j++)
        //    {
        //        _blyncLightHelper.TurnOnRGBLights(0, Convert.ToByte(j / 2), Convert.ToByte(j), Convert.ToByte(j /2));
        //        Thread.Sleep(25);
        //    }
        //}
    }
}
