﻿using ELearningBackend.Models;
using ELearningBackend.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;
        public ExamController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exam>> GetExamsAsync([FromRoute] int id)
        {
            return Ok(await _unitOfWork.Exams.GetFullExamAsync(id));
        }

        [HttpGet("Topic/{TopicId}")]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestionsByTopicAsync([FromRoute] int TopicId)
        {

                return Ok(await _unitOfWork.Questions.GetByTopicAsync(TopicId));
        }

        [HttpPost]
        public async Task<ActionResult> AddExamAsync(Exam exam)
        {
            await _unitOfWork.Exams.AddAsync(exam);
            await _unitOfWork.SaveAsync();
            return Ok(exam);
        }
        [HttpPut]
        public async Task<ActionResult> EditExamAsync(Exam exam)
        {
            _unitOfWork.Exams.Update(exam);
            await _unitOfWork.SaveAsync();
            return Ok(exam);
        }
    }
}