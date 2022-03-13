using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartHR.Dashboard.Data.IRepositories;
using SmartHR.Dashboard.Domain.Common;
using SmartHR.Dashboard.Domain.Entities.Interviews;
using SmartHR.Dashboard.Domain.Enums;
using SmartHR.Dashboard.Service.Extensions;
using SmartHR.Dashboard.Service.Helpers;
using SmartHR.Dashboard.Service.Interfaces;
using SmartHR.Dashboard.Service.ViewModels.Interviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Service.Services
{
    public class InterviewerService : IInterviewerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;
        public InterviewerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async ValueTask<BaseResponse<CollectionResult<Interview>>> GetRequestsAsync(int pageSize, int pageIndex, InterviewStatus status)
        {
            var response = new BaseResponse<CollectionResult<Interview>>();

            var interviews = (await _unitOfWork.Interviews.GetAllAsync(p => 
                p.InterviewerId == HttpContextHelper.UserId && 
                p.Status == status)).Include(p => p.Applicant);

            response.Data = new CollectionResult<Interview>(interviews.Count(), interviews.ToPagination(pageSize, pageIndex));

            return response;
        }

        public async ValueTask<BaseResponse<FeedbackApplicant>> LeaveFeedbackAsync(FeedbackViewModel feedbackViewModel)
        {
            var response = new BaseResponse<FeedbackApplicant>();

            var feedback = await _unitOfWork.Interviews.LeaveFeedbackAsync(this.mapper.Map<FeedbackApplicant>(feedbackViewModel));

            response.Data = feedback;

            return response;
        }

        public async ValueTask<BaseResponse<Interview>> UpdateStatusAsync(UpdateInterviewStatusViewModel updateModel)
        {
            var response = new BaseResponse<Interview>();

            var interview = await _unitOfWork.Interviews.GetAsync(p => p.Id == updateModel.Id);
            if(interview is null)
            {
                response.Error = new ErrorModel(404, "Interview not found");
                return response;
            }

            interview.Status = updateModel.Status;
            interview.Update();

            await _unitOfWork.CompleteTaskAsync();

            response.Data = interview;

            return response;
        }
    }
}
