using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.AccountApplication;
using Milmom_Service.Model.Request.Slider;
using Milmom_Service.Model.Response.AccountApplication;
using Milmom_Service.Model.Response.Product;
using Milmom_Service.Model.Response.Slider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milmom_Service.IService
{
    public interface ISliderService
    {
        Task<BaseResponse<IEnumerable<GetSliderForHomePageResponse>>> GetSliderForHomepage();
        Task<Boolean> DeleteSlider(int id);
        Task<BaseResponse<GetSliderByIdResponse>> GetSliderByIdFromBase(int id);
        Task<BaseResponse<IEnumerable<GetAllSliderForStaffResponse>>> GetAllSliderFromBase();
        Task<BaseResponse<UpdateSliderRequest>> UpdateSliderFromBase(int id, UpdateSliderRequest request);
        Task<BaseResponse<AddSliderRequest>> CreateSliderFromBase(AddSliderRequest request);

    }
}
