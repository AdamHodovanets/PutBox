using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PutBoxService
{
    public class PBoxService : IPBoxService
    {
        public string GetData(int value)
        {
            
            return $"You entered: {value}";
        }

        public bool Registration()
        {
            throw new NotImplementedException();
        }

        public bool Login()
        {
            throw new NotImplementedException();
        }

        public void databaseFilePut(string varFilePath)
        {
            throw new NotImplementedException();
        }

        public void databaseFileRead(string varID, string varPathToNewLocation)
        {
            throw new NotImplementedException();
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
