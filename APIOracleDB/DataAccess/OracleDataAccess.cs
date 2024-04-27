using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using APIOracleDB.Models;
using APIOracleDB.Repository;

namespace APIOracleDB.DataAccess
{


    public class OracleDataAccess : IDataAccess
    {
        private readonly string _connectionString;

        public OracleDataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("OracleConnection");
        }

        public List<PayItem> GetItemsFromStoredProcedure()
        {
            List<PayItem> items = new List<PayItem>();

            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                string storedProcedureName = "CreateSPGetPayitems";
                using (OracleCommand command = new OracleCommand(storedProcedureName, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Add any input parameters if required
                    // command.Parameters.Add("paramName", OracleDbType.Varchar2).Value = paramValue;

                    connection.Open();
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PayItem item = new PayItem
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                ITEM = reader.GetString(reader.GetOrdinal("ITEM")),
                                ISPECYR = reader.GetString(reader.GetOrdinal("ISPECYR")),
                                ICONTCLS = reader.GetString(reader.GetOrdinal("ICONTCLS")),
                                IFOLDOR = reader.GetString(reader.GetOrdinal("IFOLDOR")),
                                IMAJOR = reader.GetString(reader.GetOrdinal("IMAJOR")),
                                IOBSELET = reader.GetString(reader.GetOrdinal("IOBSELET")),
                                ILREQSUP = reader.GetString(reader.GetOrdinal("ILREQSUP")),
                                IPRICEH = reader.GetDecimal(reader.GetOrdinal("IPRICEH")),
                                ITEMCLSS = reader.GetString(reader.GetOrdinal("ITEMCLSS")),
                                ITEMCONV = reader.GetString(reader.GetOrdinal("ITEMCONV")),
                                ITEMTYPE = reader.GetString(reader.GetOrdinal("ITEMTYPE")),
                                IUNITS = reader.GetString(reader.GetOrdinal("IUNITS")),
                                IUNITSCM = reader.GetString(reader.GetOrdinal("IUNITSCM")),
                                IUNITSLS = reader.GetString(reader.GetOrdinal("IUNITSLS")),
                                IDESCR = reader.GetString(reader.GetOrdinal("IDESCR")),
                                IDESCRL = reader.GetString(reader.GetOrdinal("IDESCRL")),
                                IDESCL2 = reader.GetString(reader.GetOrdinal("IDESCL2")),
                                IEEOITEM = reader.GetString(reader.GetOrdinal("IEEOITEM")),
                                ISPCLITM = reader.GetString(reader.GetOrdinal("ISPCLITM")),
                                ASPHADJ = reader.GetDecimal(reader.GetOrdinal("ASPHADJ")),
                                IREGFLAG = reader.GetString(reader.GetOrdinal("IREGFLAG")),
                                ALTITMID = reader.GetString(reader.GetOrdinal("ALTITMID")),
                                EEOPCT = reader.GetDecimal(reader.GetOrdinal("EEOPCT")),
                                FUELADJ = reader.GetDecimal(reader.GetOrdinal("FUELADJ")),
                                ILDT1 = reader.GetDateTime(reader.GetOrdinal("ILDT1")),
                                ILDT2 = reader.GetDateTime(reader.GetOrdinal("ILDT2")),
                                ILDT3 = reader.GetDateTime(reader.GetOrdinal("ILDT3")),
                                ILFLG1 = reader.GetString(reader.GetOrdinal("ILFLG1")),
                                ILNUM1 = reader.GetInt32(reader.GetOrdinal("ILNUM1")),
                                ILSST1 = reader.GetString(reader.GetOrdinal("ILSST1")),
                                ILLST1 = reader.GetString(reader.GetOrdinal("ILLST1"))
                            };
                            items.Add(item);
                        }
                    }
                }
            }

            return items;
        }

        public List<PayItem> GetItemsFromQuery()
        {
            List<PayItem> items = new List<PayItem>();

            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                string query = "SELECT * FROM DOTEIEBD.PAYITEM.MV_ITEMLIST FETCH FIRST 1000 ROWS ONLY";
                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    connection.Open();
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PayItem item = new PayItem
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                ITEM = reader.GetString(reader.GetOrdinal("ITEM")),
                                ISPECYR = reader.GetString(reader.GetOrdinal("ISPECYR")),
                                ICONTCLS = reader.GetString(reader.GetOrdinal("ICONTCLS")),
                                IFOLDOR = reader.GetString(reader.GetOrdinal("IFOLDOR")),
                                IMAJOR = reader.GetString(reader.GetOrdinal("IMAJOR")),
                                IOBSELET = reader.GetString(reader.GetOrdinal("IOBSELET")),
                                ILREQSUP = reader.GetString(reader.GetOrdinal("ILREQSUP")),
                                IPRICEH = reader.GetDecimal(reader.GetOrdinal("IPRICEH")),
                                ITEMCLSS = reader.GetString(reader.GetOrdinal("ITEMCLSS")),
                                ITEMCONV = reader.GetString(reader.GetOrdinal("ITEMCONV")),
                                ITEMTYPE = reader.GetString(reader.GetOrdinal("ITEMTYPE")),
                                IUNITS = reader.GetString(reader.GetOrdinal("IUNITS")),
                                IUNITSCM = reader.GetString(reader.GetOrdinal("IUNITSCM")),
                                IUNITSLS = reader.GetString(reader.GetOrdinal("IUNITSLS")),
                                IDESCR = reader.GetString(reader.GetOrdinal("IDESCR")),
                                IDESCRL = reader.GetString(reader.GetOrdinal("IDESCRL")),
                                IDESCL2 = reader.GetString(reader.GetOrdinal("IDESCL2")),
                                IEEOITEM = reader.GetString(reader.GetOrdinal("IEEOITEM")),
                                ISPCLITM = reader.GetString(reader.GetOrdinal("ISPCLITM")),
                                ASPHADJ = reader.GetDecimal(reader.GetOrdinal("ASPHADJ")),
                                IREGFLAG = reader.GetString(reader.GetOrdinal("IREGFLAG")),
                                ALTITMID = reader.GetString(reader.GetOrdinal("ALTITMID")),
                                EEOPCT = reader.GetDecimal(reader.GetOrdinal("EEOPCT")),
                                FUELADJ = reader.GetDecimal(reader.GetOrdinal("FUELADJ")),
                                ILDT1 = reader.GetDateTime(reader.GetOrdinal("ILDT1")),
                                ILDT2 = reader.GetDateTime(reader.GetOrdinal("ILDT2")),
                                ILDT3 = reader.GetDateTime(reader.GetOrdinal("ILDT3")),
                                ILFLG1 = reader.GetString(reader.GetOrdinal("ILFLG1")),
                                ILNUM1 = reader.GetInt32(reader.GetOrdinal("ILNUM1")),
                                ILSST1 = reader.GetString(reader.GetOrdinal("ILSST1")),
                                ILLST1 = reader.GetString(reader.GetOrdinal("ILLST1"))
                            };
                            items.Add(item);
                        }
                    }
                }
            }

            return items;
        }
    }

}



