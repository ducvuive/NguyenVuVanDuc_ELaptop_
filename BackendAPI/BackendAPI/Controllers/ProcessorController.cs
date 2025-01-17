﻿using AutoMapper;
using BackendAPI.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShareView.DTO;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessorController : ControllerBase
    {
        private readonly UserDbContext _context;
        private readonly IMapper _mapper;

        public ProcessorController(UserDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/BoXuLies
        [HttpGet]
        public async Task<ActionResult<List<ProcessorDTO>>> GetBoXuLy()
        {
            var boXuLy = await _context.Processor.ToListAsync();
            return _mapper.Map<List<ProcessorDTO>>(boXuLy);
        }

        // GET: api/BoXuLies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProcessorDTO>> GetBoXuLy(int id)
        {
            var boXuLy = await _context.Processor.FindAsync(id);

            if (boXuLy == null)
            {
                return NotFound();
            }

            return _mapper.Map<ProcessorDTO>(boXuLy);
        }
    }
}
