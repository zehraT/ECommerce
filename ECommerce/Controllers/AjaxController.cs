﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce.DTO;
using ECommerce.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class AjaxController : Controller
    {
        private static readonly AjaxMethod AjaxMethod = new AjaxMethod();
        
        [Route("/api")]
        public JsonResult Handle()
        {
            DTO.AjaxResponseDto ajaxResponse = new DTO.AjaxResponseDto();

            string json = HttpContext.Request.Form["JSON"].ToString();
            DTO.AjaxRequestDto ajaxRequest = Newtonsoft.Json.JsonConvert.DeserializeObject<DTO.AjaxRequestDto>(json);

            if (ajaxRequest.Method == "SaveProduct")
            {
                AjaxMethod.SaveProduct(ajaxRequest.Json);
            }
            else if (ajaxRequest.Method == "ProductsByCategoryId")
            {
                ajaxResponse.Dynamic = AjaxMethod.ProductsByCategoryId(ajaxRequest.Json);
            }
            else if (ajaxRequest.Method == "RemoveProduct")
            {
                ajaxResponse.Dynamic = AjaxMethod.RemoveProduct(ajaxRequest.Json);
            }
            else if (ajaxRequest.Method == "SaveContact")
            {
                AjaxMethod.SaveContact(ajaxRequest.Json);
            }

            return new JsonResult(ajaxResponse);
        }
    }

    public class AjaxMethod
    {
        private static readonly Adapter.ProductAdapter productAdapter=new Adapter.ProductAdapter();
        public void SaveContact(string json)
        {
            DTO.ContactSaveDto contactSave = Newtonsoft.Json.JsonConvert.DeserializeObject<DTO.ContactSaveDto>(json);

            Data.Models.Contact contact = new Data.Models.Contact()
            {
                Name = contactSave.Name,
                Surname = contactSave.Surname,
                Message = contactSave.Message

            };

            contact = productAdapter.Insert<Data.Models.Contact>(contact);
        }


        public bool RemoveProduct(string json)
        {
            bool result = true;

            DTO.ProductRemoveDto productRemove = Newtonsoft.Json.JsonConvert.DeserializeObject<DTO.ProductRemoveDto>(json);

            productAdapter.Delete<Data.Models.Product>(productRemove.ProductId);
            
            return result;
        }

        public void SaveProduct(string json)
        {
            DTO.ProductSaveDto productSave = Newtonsoft.Json.JsonConvert.DeserializeObject<DTO.ProductSaveDto>(json);

            Data.Models.Product product=new Data.Models.Product()
            {
                Name = productSave.ProductName,
                Description = productSave.ProductDescription,
                StateId = (int)Enums.State.Active,
                CategoryId = productSave.CategoryId,
                CreateDate = DateTime.UtcNow,

            };

            product = productAdapter.Insert<Data.Models.Product>(product);

        }

        public List<Data.Models.Product> ProductsByCategoryId(string json)
        {
            List<Data.Models.Product> result = new List<Data.Models.Product>();
            DTO.ProductsByCategoryId productsByCategoryId = Newtonsoft.Json.JsonConvert.DeserializeObject<DTO.ProductsByCategoryId>(json);
            IQueryable<Product> products= productAdapter.Get<Data.Models.Product>();
            result = products.Include(a => a.Category).Where(a => a.CategoryId == productsByCategoryId.CategoryId).ToList();

            return result;
        }
    }
}