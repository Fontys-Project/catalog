﻿using InventoryLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryLogic.Facade
{
    public class CrudDTOFacade<DomainModel, DataTransferObject> : ICrudFacade<DataTransferObject> where DomainModel : IDataAssignable<DataTransferObject> where DataTransferObject : IHasUniqueObjectId, new()
    // TODO: remove new() after DomainModel
    {
        protected readonly IRepositoryFactory repoFactory;

        public CrudDTOFacade(IRepositoryFactory repoFactory)
        {
            this.repoFactory = repoFactory;
        }

        public List<DataTransferObject> GetAll()
        {
            List<DataTransferObject> newViews = new List<DataTransferObject>();
            List<DomainModel> records = repoFactory.GetCrudRepository<DomainModel>().GetAll();

            foreach (DomainModel record in records)
            {
                DataTransferObject newView = new DataTransferObject();
                record.ConvertToDTO(newView);
                newViews.Add(newView);
            }

            return newViews;
        }

        public DataTransferObject Get(int id)
        {
            DataTransferObject newView = new DataTransferObject();
            DomainModel obj = repoFactory.GetCrudRepository<DomainModel>().Get(id);
            obj.ConvertToDTO(newView);

            return newView;
        }

        public DataTransferObject Add(DataTransferObject obj)
        {
            DomainModel newObj = repoFactory.GetCrudRepository<DomainModel>().CreateNew();

            newObj.ConvertFromDTO(obj);

            DomainModel domainModel = repoFactory.GetCrudRepository<DomainModel>().Add(newObj);
            domainModel.ConvertToDTO(obj);

            return obj;
        }

        public Boolean Remove(int id)
        {
            repoFactory.GetCrudRepository<DomainModel>().Remove(id);
            return true;
        }

        public Boolean Modify(DataTransferObject obj)
        {
            DomainModel objToEdit = repoFactory.GetCrudRepository<DomainModel>().Get(obj.Id);
            objToEdit.ConvertFromDTO(obj);

            repoFactory.GetCrudRepository<DomainModel>().Modify(objToEdit);
            return true;
        }
    }
}
