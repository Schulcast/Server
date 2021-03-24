using System;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schulcast.Server.Data;
using Schulcast.Server.Models;
using Schulcast.Server.Repositories;

namespace Schulcast.Server.Controllers
{
	[ApiController, Route("[controller]"), Authorize]
	public class FileController : ControllerBase
	{
		public FileController(UnitOfWork unitOfWork) : base(unitOfWork) { }

		[HttpGet("{id}"), AllowAnonymous]
		public IActionResult Get([FromRoute] int id)
		{
			return File(System.IO.File.OpenRead(UnitOfWork.FileRepository.Get(id).Path), "image/jpeg");
		}

		[HttpGet("{directory}"), AllowAnonymous]
		public IActionResult Get([FromRoute] string directory)
		{
			return Ok(UnitOfWork.FileRepository.GetByFolder(FileDirectories.Slides));
		}

		[HttpPost("{directory}"), Authorize(Roles = MemberRoles.Admin)]
		public IActionResult Post([FromRoute] string directory, [FromForm] IFormFile formFile)
		{
			if (Path.GetExtension(formFile.FileName).ToLower() != ".jpg")
			{
				return BadRequest("Only JPG files are allowed");
			}

			if (formFile.Length > 1_000_000)
			{
				return BadRequest("Only files smaller than 1MB are allowed");
			}

			var file = new Models.File
			{
				Path = $"{FileRepository.uploadDirectoryName}/{directory}/{Guid.NewGuid().ToString()}.jpg"
			};

			using (var stream = System.IO.File.Create(file.Path))
			{
				formFile.CopyTo(stream);
			}

			UnitOfWork.FileRepository.Add(file);
			UnitOfWork.CommitChanges();

			return Ok(formFile);
		}

		[HttpDelete("{id}"), Authorize(Roles = MemberRoles.Admin)]
		public IActionResult Delete([FromRoute] int id)
		{
			UnitOfWork.FileRepository.Delete(id);
			return Ok();
		}
	}
}