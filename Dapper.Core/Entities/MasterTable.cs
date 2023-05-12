using System;

namespace Dapper.Core.Entities
{
    public class MasterTable
    {
        public int ID { get; set; }


        public string DataValue { get; set; }


        public string DataText { get; set; }


        public string DataFor { get; set; }


        public bool IsActive { get; set; }


        public DateTime CreatedDate { get; set; }
    }
}
