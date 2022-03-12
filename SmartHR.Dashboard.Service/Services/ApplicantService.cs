﻿using AutoMapper;
using SmartHR.Dashboard.Data.IRepositories;
using SmartHR.Dashboard.Domain.Common;
using SmartHR.Dashboard.Domain.Entities.Interviews;
using SmartHR.Dashboard.Domain.Enums;
using SmartHR.Dashboard.Service.Interfaces;
using SmartHR.Dashboard.Service.ViewModels.Interviews;
using System.Threading.Tasks;

namespace SmartHR.Dashboard.Service.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public ApplicantService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Interview>> SendRequestAsync(InterviewViewModel interview)
        {
            var response = new BaseResponse<Interview>();

            var interviewer = await _unitOfWork.Users.GetAsync(p => p.Id == interview.InterviewerId && p.Role == UserType.Interviewer);
            if (interviewer is null)
            {
                response.Error = new ErrorModel(404, "Interviewer not found");
                return response;
            }

            var applicant = await _unitOfWork.Users.GetAsync(p => p.Id == interview.ApplicantId && p.Role == UserType.Applicant);
            if (applicant is null)
            {
                response.Error = new ErrorModel(404, "Applicant not found");
                return response;
            }

            // check for exist interview with this interviewer
            var oldInterview = await _unitOfWork.Interviews.GetAsync(p =>
                p.InterviewerId == interview.InterviewerId && p.ApplicantId == interview.ApplicantId);
            if (oldInterview is not null)
            {
                response.Error = new ErrorModel(404, "Already, request sent before");
                return response;
            }

            // map and add new interview
            var mapped = _mapper.Map<Interview>(interview);
            var newInterview = await _unitOfWork.Interviews.CreateAsync(mapped);

            response.Data = newInterview;

            await _unitOfWork.CompleteTaskAsync();

            return response;
        }
    }
}