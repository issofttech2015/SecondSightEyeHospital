using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace SecondSightWeb.Common_Controle
{
    public class CRMSerializer
    {
        private readonly JavaScriptSerializer serializer;

        #region Singleton Object
        private static CRMSerializer instance;
        private static object syncRoot = new Object();

        private CRMSerializer() { }

        public static CRMSerializer Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new CRMSerializer(new JavaScriptSerializer());
                        }
                    }
                }
                return instance;
            }
        }
        #endregion

        public CRMSerializer(JavaScriptSerializer serializer)
        {
            this.serializer = serializer;
            serializer.MaxJsonLength = int.MaxValue;
        }
        public T Deserialize<T>(T t, dynamic requestedObject)
        {
            try
            {
                t = serializer.Deserialize<T>(requestedObject);
            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
            }
            return t;
        }

        public dynamic Serialize<T>(T trequest, dynamic response)
        {
            try
            {
                response = serializer.Serialize(trequest);
            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
            }
            return response;
        }
    }
}
