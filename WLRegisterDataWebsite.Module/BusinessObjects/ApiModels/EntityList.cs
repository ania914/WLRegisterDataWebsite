﻿using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using System.Collections.Generic;
using WLRegisterDataWebsite.Module.BusinessObjects.Models;
using WLRegisterDataWebsite.Module.Services.Abstract;

namespace WLRegisterDataWebsite.Module.BusinessObjects.ApiModels
{
    [DomainComponent]
    public class EntityList : NonPersistentBaseObject, IGetResult, ICacheResult
    {
        private List<EntityModel> subject = new List<EntityModel>();
        private string requestDateTime;
        private string requestId;

        public List<EntityModel> Subjects
        {
            get => subject;
            set => SetPropertyValue(ref subject, value);
        }

        public string RequestDateTime
        {
            get => requestDateTime;
            set => SetPropertyValue(ref requestDateTime, value);
        }

        public string RequestId
        {
            get => requestId;
            set => SetPropertyValue(ref requestId, value);
        }

        public void AddCachedData(IEnumerable<EntityModel> entityModels)
        {
            if (Subjects == null)
                Subjects = new List<EntityModel>();

            Subjects.AddRange(entityModels);
        }

        public IEnumerable<EntityModel> GetResult()
        {
            return Subjects;
        }
    }
}
