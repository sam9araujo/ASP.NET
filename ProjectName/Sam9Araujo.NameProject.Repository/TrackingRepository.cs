using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sam9araujo.NameProject.Domain;
using Sam9araujo.NameProject.Repository.DAL;

namespace Sam9araujo.NameProject.Repository
{
    public class TrackingRepository :BaseRepository<Tracking,TrackingDAL,TrackingRepository>,IRepositoryBase
    {
    }
}
