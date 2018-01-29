﻿using System.Threading.Tasks;
using FilterLists.Data.Entities.Junctions;
using FilterLists.Services.Models.Seed.Junctions;
using FilterLists.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace FilterLists.Api.V1.Controllers
{
    public class SoftwareSyntaxesController : BaseController
    {
        private readonly SeedService seedService;

        public SoftwareSyntaxesController(SeedService seedService)
        {
            this.seedService = seedService;
        }

        [HttpGet]
        public async Task<IActionResult> Seed()
        {
            return Json(await seedService.GetAllAsync<SoftwareSyntax, SoftwareSyntaxSeedDto>());
        }
    }
}