using AutoMapper;
using Milmom_Repository.IRepository;
using Milmom_Repository.Repository;
using Milmom_Service.IService;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.Product;
using Milmom_Service.Model.Request.Slider;
using Milmom_Service.Model.Response.AccountApplication;
using Milmom_Service.Model.Response.Product;
using Milmom_Service.Model.Response.Slider;
using Milmom_Service.Models.Enums;
using MilmomStore_BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.Service
{
    public class SliderService : ISliderService
    {
        private readonly IMapper _mapper;
        private readonly ISliderRepository _sliderRepository;

        public SliderService(IMapper mapper, ISliderRepository sliderRepository)
        {
            _mapper = mapper;
            _sliderRepository = sliderRepository;
        }

        public async Task<BaseResponse<AddSliderRequest>> CreateSliderFromBase(AddSliderRequest request)
        {
            Slider slider = _mapper.Map<Slider>(request);
            await _sliderRepository.AddAsync(slider);

            var response = _mapper.Map<AddSliderRequest>(slider);
            return new BaseResponse<AddSliderRequest>("Create slider as base success", StatusCodeEnum.Created_201, response);
        }

        public async Task<bool> DeleteSlider(int id)
        {
            var existingSlider = await _sliderRepository.GetByIdAsync(id);
            if (existingSlider == null)
            {
                return false;
            }
            return await _sliderRepository.DeleteSlider(existingSlider);
        }

        public async Task<BaseResponse<IEnumerable<GetAllSliderForStaffResponse>>> GetAllSliderFromBase()
        {
            IEnumerable<Slider> sliders = await _sliderRepository.GetAllAsync();
            var slider = _mapper.Map<IEnumerable<GetAllSliderForStaffResponse>>(sliders);
            return new BaseResponse<IEnumerable<GetAllSliderForStaffResponse>>("Get all slider for staff as base success",
                StatusCodeEnum.OK_200, slider);
        }

        public async Task<BaseResponse<GetSliderByIdResponse>> GetSliderByIdFromBase(int id)
        {
            Slider slider = await _sliderRepository.GetByIdAsync(id);
            var result = _mapper.Map<GetSliderByIdResponse>(slider);
            return new BaseResponse<GetSliderByIdResponse>("Get slider by id success", StatusCodeEnum.OK_200,
                result);
        }

        public async Task<BaseResponse<IEnumerable<GetSliderForHomePageResponse>>> GetSliderForHomepage()
        {
            IEnumerable<Slider> sliders = await _sliderRepository.GetSliderForHomePage();
            var slider = _mapper.Map<IEnumerable<GetSliderForHomePageResponse>>(sliders);
            return new BaseResponse<IEnumerable<GetSliderForHomePageResponse>>("Get all sliders for home page success",
                StatusCodeEnum.OK_200, slider);
        }

        public async Task<BaseResponse<UpdateSliderRequest>> UpdateSliderFromBase(int id, UpdateSliderRequest request)
        {
            Slider existingSlider = await _sliderRepository.GetByIdAsync(id);
            _mapper.Map(request, existingSlider);
            await _sliderRepository.UpdateAsync(existingSlider);

            var result = _mapper.Map<UpdateSliderRequest>(existingSlider);
            return new BaseResponse<UpdateSliderRequest>("Update slider as base success", StatusCodeEnum.OK_200, result);
        }
    }
}
