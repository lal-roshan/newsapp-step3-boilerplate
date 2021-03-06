﻿using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Exceptions;
using System;
using System.Threading.Tasks;
namespace NewsAPI.Controllers
{
    /// <summary>
    /// Api controller for handling Http requests regarding reminder entity
    /// </summary>
    [Route("/api/[controller]")]
    [ApiController]
    public class ReminderController : ControllerBase
    {
        /// <summary>
        /// readonly property for the service class required
        /// </summary>
        readonly IReminderService reminderService;

        /// <summary>
        /// Paramterised constructor for injecting service class property
        /// </summary>
        /// <param name="reminderService"></param>
        public ReminderController(IReminderService reminderService)
        {
            this.reminderService = reminderService;
        }

        /// <summary>
        /// Method for fetching reminder corresponding to a news id
        /// </summary>
        /// <param name="newsId">The id of the news whose reminder is to be fetched</param>
        /// <returns>The reminder of the mentioned news</returns>
        /// <response code="200">If the reminder was fetched successfuly</response>
        /// <response code="404">If no reminder was found for the news</response>
        /// <response code="500">If some error occurred</response>
        [HttpGet("{newsId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int newsId)
        {
            try
            {
                return Ok(await reminderService.GetReminderByNewsId(newsId));
            }
            catch (ReminderNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Some error occurred, please try again later !!");
            }
        }

        /// <summary>
        /// Method to add a reminder
        /// </summary>
        /// <param name="reminder">The reminder object that is to be added</param>
        /// <returns>The added reminder</returns>
        /// <response code="201">If the reminder was created successfuly</response>
        /// <response code="409">If the reminder is already present</response>
        /// <response code="500">If some error occurred</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(Reminder reminder)
        {
            try
            {
                reminder = await reminderService.AddReminder(reminder);
                return Created("api/reminder", reminder);
            }
            catch (ReminderAlreadyExistsException exc)
            {
                return Conflict(exc.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Some error occurred, please try again later !!");
            }
        }

        /// <summary>
        /// Method to delete a reminder
        /// </summary>
        /// <param name="id">The id of the reminder to be deleted</param>
        /// <returns>True if removal was success</returns>
        /// <response code="200">If the reminder was removed successfully</response>
        /// <response code="404">If the reminder was not found</response>
        /// <response code="500">If some error occurred</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await reminderService.RemoveReminder(id));
            }
            catch (ReminderNotFoundException exc)
            {
                return NotFound(exc.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Some error occurred, please try again later !!");
            }
        }
    }
}
