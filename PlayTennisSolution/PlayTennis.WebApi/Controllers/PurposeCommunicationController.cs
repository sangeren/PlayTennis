﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlayTennis.Bll;
using PlayTennis.Model.Dto;

namespace PlayTennis.WebApi.Controllers
{
    public class PurposeCommunicationController : ApiController
    {
        public PurposeCommunicationController()
        {
            UserLoginService = new UserLoginService();
            ExercisePurposeService = new ExercisePurposeService();
            PurposeCommunicationService = new PurposeCommunicationService();
        }
        public UserLoginService UserLoginService { get; set; }
        public ExercisePurposeService ExercisePurposeService { get; set; }
        public UserInformationService UserInformationService { get; set; }
        public PurposeCommunicationService PurposeCommunicationService { get; set; }

        // GET: api/PurposeCommunication
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PurposeCommunication/5
        public ExercisePurposeIngDto Get(Guid id)
        {
            var result = ExercisePurposeService.GetUserExercisePurpose(id);
            if (result != null)
            {
                result.Communications = PurposeCommunicationService.PurposeCommunications(result.ExercisePurpose.Id);
            }

            return result;
        }

        // POST: api/PurposeCommunication
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PurposeCommunication/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PurposeCommunication/5
        public void Delete(int id)
        {
        }
    }
}
