﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Geres4U.Data.DataModels;

namespace Geres4U.Data
{
    public class PointOfInterestData : IPointOfInterestData
    {
        private readonly IDataAccess _db;

        public PointOfInterestData(IDataAccess db)
        {
            _db = db;
        }

        public Task<List<PointOfInterestDataModel>> GetPointsOfInterest()
        {
            string sql = @"SELECT * FROM geres4udb.pointofinterest WHERE isSugestion = 0";
            return _db.LoadData<PointOfInterestDataModel, dynamic>(sql, new { });
        }

        public Task<List<PointOfInterestDataModel>> getSugestionsPointsOfInterest()
        {
            string sql = @"SELECT * FROM geres4udb.pointofinterest WHERE isSugestion = 1";
            return _db.LoadData<PointOfInterestDataModel, dynamic>(sql, new { });
        }

        public Task<List<PointOfInterestDataModel>> getPointOfInterest(PointOfInterestDataModel p)
        {
            string sql = @"SELECT * FROM geres4udb.pointofinterest WHERE ID = " + p.ID;
            return _db.LoadData<PointOfInterestDataModel, dynamic>(sql, p);
        }

        public Task InsertPointOfInterestWithoutDescriptionAndImage(PointOfInterestDataModel pointOfInterest)
        {
            string sql = @"INSERT INTO geres4udb.pointofinterest(ID, Name, Images, Lat, Long, isSugestion, Description)
                           VALUES (" + pointOfInterest.ID +", @Name, NULL, " + pointOfInterest.Lat +", " + pointOfInterest.Long + ", 0, NULL) END";
            return _db.SaveData(sql, pointOfInterest);
        }

        public Task InsertPointOfInterestWithDescriptionWithoutImage(PointOfInterestDataModel pointOfInterest)
        {
            string sql = @"INSERT INTO geres4udb.pointofinterest(ID, Name, Images, Lat, Long, isSugestion, Description)
                           VALUES (" + pointOfInterest.ID + ", @Name, NULL, " + pointOfInterest.Lat + ", " + pointOfInterest.Long + ", 0, @Description) END";  
            return _db.SaveData(sql, pointOfInterest);
        }

        public Task InsertPointOfInterestWithDescriptionAndImagePath(PointOfInterestDataModel pointOfInterest)
        {
            string sql = @"INSERT INTO geres4udb.pointofinterest(ID, Name, Images, Lat, Long, isSugestion, Description)
                            VALUES (" + pointOfInterest.ID + ", @Name, @Images, " + pointOfInterest.Lat + ", " + pointOfInterest.Long + ", 0, NULL) END";
            return _db.SaveData(sql, pointOfInterest);
        }

        // Nunca poderá adicionar sugestões c imagens visto que a imagem é o local path
        public Task InsertPointOfInterestSugestionWithoutDescription(PointOfInterestDataModel pointOfInterest)
        {
            string sql = @"INSERT INTO geres4udb.pointofinterest(ID, Name, Images, Lat, Long, isSugestion, Description)
                           VALUES (" + pointOfInterest.ID + ", @Name, NULL, " + pointOfInterest.Lat + ", " + pointOfInterest.Long + ", 1, NULL) END";
            return _db.SaveData(sql, pointOfInterest);
        }

        public Task InsertPointOfInterestSugestion(PointOfInterestDataModel pointOfInterest)
        {
            string sql = @"INSERT INTO geres4udb.pointofinterest(ID, Name, Images, Lat, Long, isSugestion, Description)
                            VALUES (" + pointOfInterest.ID + ", @Name, NULL, " + pointOfInterest.Lat + ", " + pointOfInterest.Long + ", 0, @Description) END";
            return _db.SaveData(sql, pointOfInterest);
        }

        public Task UpdatePointOfInterest(PointOfInterestDataModel pointOfInterest)
        {
            string sql = @"UPDATE geres4udb.pointofinterest 
                           SET Name = @Name, Images = @Images, Lat = " + pointOfInterest.Lat + ",  Long = " + pointOfInterest.Long + ",  isSugestion = " +pointOfInterest.isSugestion + @", Description = @Description
                           WHERE ID = " + pointOfInterest.ID;
            return _db.SaveData(sql, pointOfInterest);
        }

        public Task RemovePointOfInterest(PointOfInterestDataModel pointOfInterest)
        {
            string sql = @"DELETE FROM geres4udb.pointofinterest
                           WHERE ID = " + pointOfInterest.ID;
            return _db.SaveData(sql, pointOfInterest);
        }

        public Task acceptPointOfInterestSugestion(PointOfInterestDataModel pointOfInterest)
        { 
            PointOfInterestDataModel p = new PointOfInterestDataModel(pointOfInterest.ID, pointOfInterest.Name,
                    pointOfInterest.Images, pointOfInterest.Lat, pointOfInterest.Long, 0,
                    pointOfInterest.Description);
            return UpdatePointOfInterest(p);
        }

        public Task addImageToPointOfInterest(PointOfInterestDataModel p, string imagePath)
        {
            p.Images = imagePath;
            return UpdatePointOfInterest(p);
        }

        public Task addDescriptionToPointOfInterest(PointOfInterestDataModel p, string description)
        {
            p.Description = description;
            return UpdatePointOfInterest(p);
        }
    }
}
