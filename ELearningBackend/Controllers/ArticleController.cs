﻿using ELearningBackend.Models;
using ELearningBackend.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ELearningBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public ArticleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetCommentById([FromRoute] int id)
        {
            return Ok(await _unitOfWork.Articles.GetArticleByIdAsync(id));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> GetFewArticles()
        {
            return Ok(await _unitOfWork.Articles.GetSomeArticleAsync());
        }


        [HttpGet("topic/{AricleId}")]
        public async Task<ActionResult<IEnumerable<Article>>> GetRelated([FromRoute] int AricleId)
        {
            return Ok(await _unitOfWork.Articles.GetRelatedAsync(AricleId));
        }

>>>>>>> 4510c06e4c2f298e093d5fdac4e668d1bd1a53cd
    }
}
