using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace FreightWebService
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://freightwebservice.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FreightWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string freightout(double date)
        {
                string result = "";
                using (OracleConnection con =
                    new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ars"].ConnectionString))
                {
                    //ARADMIN7.
                    OracleCommand comand =
                        new OracleCommand("select * from (select TRANSPORTADORA,REGISTRO_DO_PROTOCOLO,NRO_OM,NRO_DOCUMENTO,ORIGEM,QUANTIDADE,TIPO_DO_MOVIMENTO,STATUS from ARADMIN7.SGOL_ORDEMDEMOVIMENTACAOREDECA where REGISTRO_DO_PROTOCOLO >" + date + " and TIPO_DO_MOVIMENTO=3 and STATUS=2 order by REGISTRO_DO_PROTOCOLO)  where ROWNUM < 100", con);
                    con.Open();

                    OracleDataReader reader = comand.ExecuteReader();

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {

                            if (reader.IsDBNull(0))
                                result += "null;";

                            else
                                result += reader.GetString(0) + ";";
                            if (reader.IsDBNull(1))
                                result += "null;";
                            else
                                result += reader.GetInt32(1) + ";";
                            //result += value.destination.ToString() + ";";
                            if (reader.IsDBNull(2))
                                result += "null;";
                            else
                                result += reader.GetString(2).Replace("0", "") + ";";
                            //result += value.origin.ToString() + ";";
                            //result += value.product.ToString() + ";";
                            if (reader.IsDBNull(3))
                                result += "null;";
                            else
                                result += reader.GetString(3) + ";";
                            //result += value.id.ToString() + ";";
                            if (reader.IsDBNull(4))
                                result += "null;";
                            else
                                result += reader.GetString(4) + ";";
                            if (reader.IsDBNull(5))
                                result += "null;";
                            else
                                result += reader.GetInt32(5) + ";";
                            if (reader.IsDBNull(6))
                                result += "null;";
                            else
                                result += reader.GetInt32(6) + ";";
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();
                    return result;

                }

        }

        [WebMethod]
        public string freightin(string nf)
        {
           
                string result = "";

                using (OracleConnection con =
                    new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ars"].ConnectionString))
                {
                    OracleCommand comand =
                        new OracleCommand("select TRANSPORTADORA,REGISTRO_DO_PROTOCOLO,NRO_OM,NRO_DOCUMENTO,ORIGEM,QUANTIDADE,TIPO_DO_MOVIMENTO from ARADMIN7.SGOL_ORDEMDEMOVIMENTACAOREDECA where NRO_DOCUMENTO =  '" + nf + "'", con);
                    con.Open();

                    OracleDataReader reader = comand.ExecuteReader();

                    if (reader.HasRows)
                    {

                        while (reader.Read())
                        {
                            
                                if (reader.IsDBNull(0))
                                    result += "null;";

                                else
                                    result += reader.GetString(0) + ";";
                                if (reader.IsDBNull(1))
                                    result += "null;";
                                else
                                    result += reader.GetString(1) + ";";
                                //result += value.destination.ToString() + ";";
                                if (reader.IsDBNull(2))
                                    result += "null;";
                                else
                                    result += reader.GetString(2).Replace("0", "") + ";";
                                //result += value.origin.ToString() + ";";
                                //result += value.product.ToString() + ";";
                                if (reader.IsDBNull(3))
                                    result += "null;";
                                else
                                    result += reader.GetString(3) + ";";
                                //result += value.id.ToString() + ";";
                                if (reader.IsDBNull(4))
                                    result += "null;";
                                else
                                    result += reader.GetString(4) + ";";
                                if (reader.IsDBNull(5))
                                    result += "null;";
                                else
                                    result += reader.GetString(5) + ";";
                                if (reader.IsDBNull(6))
                                    result += "null;";
                                else
                                    result += reader.GetString(6) + ";";
                            
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }
                    reader.Close();
                    return result;
                }
           
        }

        [WebMethod]
        public bool freightCompare(string nf)
        {


            using (OracleConnection con =
                new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ars"].ConnectionString))
            {
                OracleCommand comand =
                    new OracleCommand("select TRANSPORTADORA,REGISTRO_DO_PROTOCOLO,NRO_OM,NRO_DOCUMENTO,ORIGEM,QUANTIDADE from ARADMIN7.SGOL_ORDEMDEMOVIMENTACAOREDECA where NRO_DOCUMENTO='" + nf + "'", con);
                con.Open();

                OracleDataReader reader = comand.ExecuteReader();

                if (reader.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        [WebMethod]
        public string freightTerminals(string nf)
        {

            string result = "";

            using (OracleConnection con =
                new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ars"].ConnectionString))
            {
                OracleCommand comand =
                    new OracleCommand("select NRO_OM,NRO_FISICO,NRO_ATIVO,MODELO from ARADMIN7.SGOL_ORDEMMOVIMENTACAOITENSR where NRO_OM = '" + nf + "'", con);
                con.Open();

                OracleDataReader reader = comand.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {

                        if (reader.IsDBNull(0))
                            result += "null;";

                        else
                            result += reader.GetString(0) + ";";
                        if (reader.IsDBNull(1))
                            result += "null;";
                        else
                            result += reader.GetString(1) + ";";
                        if (reader.IsDBNull(2))
                            result += "null;";
                        else
                            result += reader.GetString(2).Replace("0", "") + ";";
                        if (reader.IsDBNull(3))
                            result += "null;";
                        else
                            result += reader.GetString(3) + ";";
                        
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                reader.Close();
                return result;
            }
        }
    }
}