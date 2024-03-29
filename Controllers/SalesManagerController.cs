﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMS_MVCDTO.Interfaces.Services;
using SMS_MVCDTO.Models.DTOs.SalesManagerDTOs;

namespace SMS_MVCDTO.Controllers
{
	//[Authorize(Roles = "SuperAdmin, SalesManager")]
	public class SalesManagerController : Controller
	{
		private readonly ISalesManagerService _saleManager;
		public SalesManagerController(ISalesManagerService saleManager)
		{
			_saleManager = saleManager;
		}

		public IActionResult Index()
		{
			//ViewBag.ShowElement1 = true;
			var saleManager = _saleManager.GetSalesManagers();
			return View(saleManager);
		}

		public IActionResult Dashboard()
		{
			//ViewBag.ShowElement1 = true;
			var saleManager = _saleManager.GetSalesManagers();
			return View(saleManager);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CreateSalesManagerRequestModel createSaleManager)
		{
			if (createSaleManager == null)
			{
				TempData["failed"] = "Incomplete details, Registration Failed";
				return View();
			}

			var existByEmail = _saleManager.ExistByEmail(createSaleManager.Email);
			if (existByEmail)
			{
				TempData["failed"] = "Email already Exist.";
				return View();
			}

			//adding profile picture
			if (Request.Form.Files.Count > 0)
			{
				IFormFile file = Request.Form.Files.FirstOrDefault();
				using (var dataStream = new MemoryStream())
				{
					await file.CopyToAsync(dataStream);
					createSaleManager.ProfilePicture = dataStream.ToArray();
				}
				_saleManager.Create(createSaleManager);
				TempData["success"] = "Registration Successful.    ";
				return RedirectToAction("Index");
			}
			_saleManager.Create(createSaleManager);
			TempData["success"] = "Registration Successful. But Kindly upload a passport size picture";
			return RedirectToAction("Index");
		}



		public IActionResult Edit(string staffId)
		{
			var saleManager = _saleManager.GetById(staffId);
			if (saleManager == null)
			{
				TempData["failed"] = "Profile not found.";
				return View();
			}
			return View(saleManager);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(SalesManagerResponseModel updateSaleManager)
		{

			var saleManager = _saleManager.Update(updateSaleManager);
			if (saleManager == null)
			{
				TempData["failed"] = "Profile not found.";
				return View();
			}
			TempData["success"] = "Profile Updated Successfully.";
			return RedirectToAction(nameof(Index));
		}

		public IActionResult DeletePreview(string staffId)
		{
			if (staffId == null)
			{
				return View();
			}
		
			var saleManager = _saleManager.GetById(staffId);

			if (saleManager == null)
			{
				TempData["failed"] = "Profile not found.";
				return View();
			}
			return View(saleManager);
		}


		//[ValidateAntiForgeryToken]
		//[HttpPost, ActionName("Delete")]
		public IActionResult Delete(string staffId)
		{
			if (staffId != null)
			{
				_saleManager.Delete(staffId);
				return RedirectToAction(nameof(Index));
			}
			return NotFound();
		}

		public IActionResult Details(string staffId)
		{
			if (staffId == null)
			{
				TempData["failed"] = "Profile not found.";
				return View();
			}

			var saleManager = _saleManager.GetById(staffId);

			if (saleManager == null)
			{
				TempData["failed"] = "Profile not found.";
				return View();
			}

			return View(saleManager);

		}
	}
}

