using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

using API.Helpers;

using Blynclight;

namespace API.Controllers
{
    public class BlyncController : ApiController
    {
        private const string slackCommandText = "text";

        private readonly BlynclightController _blynclightController;

        private readonly int _deviceId = 0;

        public BlyncController()
        {
            _blynclightController = new BlynclightController();

            _blynclightController.InitBlyncDevices();
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

        [HttpGet]
        [Route("api/Blync/On/{deviceId}/{red}/{green}/{blue}")]
        public bool TurnRGBLedOn([FromBody] int deviceId, byte red, byte green, byte blue)
        {
            return _blynclightController.TurnRGBLedOn(deviceId, red, green, blue);
            //return _blyncLightHelper.SetColor(deviceId, rgb);
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
            _blynclightController.TurnLedOff(_deviceId);
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

        private async Task<NameValueCollection> GetRequestParameters()
        {
            var query = await Request.Content.ReadAsStringAsync();

            var uriBuilder = new UriBuilder(Request.RequestUri) { Query = query };
            var uri = uriBuilder.Uri;

            NameValueCollection parameters = uri.ParseQueryString();
            return parameters;
        }
    }
}
