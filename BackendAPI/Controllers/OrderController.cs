﻿using BackendAPI.DTO;
using BackendAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace BackendAPI.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("getAllOrders")]
        [Authorize(Roles = "admin")]
        public IActionResult GetAllOrders()
        {
            _orderService.CheckCompletedOrders();
            return Ok(_orderService.GetAllOrders());
        }

        [HttpPost("cancelOrder")]
        public IActionResult CancelOrder(string orderId)
        {
            _orderService.CancelOrder(orderId);
            return Ok();
        }


        [HttpGet("getNonCanceledOrders")]
        [Authorize(Roles = "shopper")]
        public IActionResult GetNonCanceledOrders(string email)
        {
            _orderService.CheckCompletedOrders();
            return Ok(_orderService.GetShopperNonCanceledOrders(email));
        }

        [HttpGet("getCompletedOrders")]
        [Authorize(Roles = "shopper")]
        public IActionResult GetCompletedOrders(string email)
        {
            _orderService.CheckCompletedOrders();
            return Ok(_orderService.GetShopperCanceledOrders(email));
        }

        [HttpPost("createOrder")]
        [Authorize(Roles = "shopper")]
        public IActionResult CreateOrder(OrderDto orderDto)
        {
            try
            {
                bool res = _orderService.CreateOrder(orderDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("completeOrder")]
        [Authorize(Roles = "seller")]
        public IActionResult DeliverOrder(string orderId)
        {
            _orderService.CompleteOrder(orderId);
            return Ok();
        }


        [HttpGet("getNewOrdersSeller")]
        [Authorize(Roles = "seller")]
        public IActionResult GetNewOrdersSeller(string email)
        {
            _orderService.CheckCompletedOrders();
            return Ok(_orderService.GetSellerNewOrders(email));
        }


        [HttpGet("getAllOrdersSeller")]
        [Authorize(Roles = "seller")]
        public IActionResult GetAllOrdersSeller(string email)
        {
            _orderService.CheckCompletedOrders();
            return Ok(_orderService.GetSellerAllOrders(email));
        }
    }
}
