using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milmom_Service.IService;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.Product;
using Milmom_Service.Model.Request.Slider;
using Milmom_Service.Model.Response.Product;
using Milmom_Service.Model.Response.Slider;
using Milmom_Service.Service;
using MilmomStore_BusinessObject.Model;

namespace MilmomStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [HttpGet]
        [Route("SliderForHomepage")]
        public async Task<ActionResult<BaseResponse<IEnumerable<GetSliderForHomePageResponse>>>> GetSliderForHomepage()
        {
            var sliders = await _sliderService.GetSliderForHomepage();
            return Ok(sliders);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<BaseResponse<Slider>>> DeleteSlider(int id)
        {
            var existingSlider = await _sliderService.GetSliderByIdFromBase(id);
            if (existingSlider == null)
            {
                return NotFound(new { message = "Slider not found" });
            }

            var success = await _sliderService.DeleteSlider(id);

            if (!success)
            {
                return BadRequest(new { message = "Failed to delete slider" });
            }

            return Ok(new { message = "Delete slider success" });
        }

        [HttpGet]
        [Route("Get For Staff")]
        public async Task<ActionResult<BaseResponse<IEnumerable<GetAllSliderForStaffResponse>>>> GetAllSliderForStaff()
        {
            var sliders = await _sliderService.GetAllSliderFromBase();
            return Ok(sliders);
        }

        [HttpPost]
        [Route("Add For Staff")]
        public async Task<ActionResult<BaseResponse<AddSliderRequest>>> CreateSliderFromBase([FromBody] AddSliderRequest request)
        {
            var slider = await _sliderService.CreateSliderFromBase(request);
            return slider;
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<BaseResponse<UpdateSliderRequest>>> UpdateSliderFromBase(int id,
            [FromBody] UpdateSliderRequest slider)
        {
            return await _sliderService.UpdateSliderFromBase(id, slider);
        }
    }
}
