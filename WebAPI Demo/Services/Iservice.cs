using System.Data;
using WebAPI_Demo.Models;

namespace WebAPI_Demo.Services
{
    public interface Iservice
    {
        void SendEmail();
        void InsertRecords(product product);

        DataTable SyncData();

        List<product> GetAllRecords();
    }
}
