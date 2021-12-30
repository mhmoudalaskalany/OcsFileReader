﻿// namespace FileReader
// {
//     public class CommentedCode
//     {
//         /// <summary>
//         /// Generating Excel File
//         /// </summary>
//         /// <param name="entities"></param>
//         /// <param name="day"></param>
//         private static void GenerateRbuchExcelFile(List<RbuchSqlRecord> entities, DateTime day)
//         {
//             if (entities.Any())
//             {
//                 Console.ForegroundColor = ConsoleColor.DarkRed;
//                 Console.WriteLine($"Generating Excel File Starting From Day : {day.ToShortDateString()}...");
//                 using var workbook = new XLWorkbook();
//                 var worksheet = workbook.Worksheets.Add("Last Day");
//                 var currentRow = 1;
//                 var properties = entities.First().GetType().GetProperties();
//                 var columnNumber = 0;
//                 // set header columns
//                 foreach (var prop in properties)
//                 {
//                     worksheet.Cell(currentRow, ++columnNumber).Value = prop.Name;
//                 }
//
//                 foreach (var record in entities)
//                 {
//                     currentRow++;
//                     worksheet.Cell(currentRow, 1).Value = record.RZELLE;
//                     worksheet.Cell(currentRow, 2).Value = record.DATUM;
//                     worksheet.Cell(currentRow, 3).Value = record.ZEIT;
//                     worksheet.Cell(currentRow, 4).Value = record.ROHSTOFF;
//                     worksheet.Cell(currentRow, 5).Value = record.BESTANDALT;
//                     worksheet.Cell(currentRow, 6).Value = record.BUCHUNG;
//                     worksheet.Cell(currentRow, 7).Value = record.BENUTZER;
//                     worksheet.Cell(currentRow, 8).Value = record.BEMERKUNG;
//                     worksheet.Cell(currentRow, 9).Value = record.ZU;
//                     worksheet.Cell(currentRow, 10).Value = record.DOSANW;
//                 }
//
//                 using var stream = new MemoryStream();
//                 workbook.SaveAs(stream);
//                 var content = stream.ToArray();
//                 var path = Configuration["ExcelPath"];
//                 Console.ForegroundColor = ConsoleColor.Yellow;
//                 Console.WriteLine($"Writing Excel File To Path {path}");
//                 bool exists = Directory.Exists(path);
//
//                 if (!exists)
//                     Directory.CreateDirectory(path);
//                 File.WriteAllBytes(path + "Rbuch Last Day.xlsx", content);
//                 Console.ForegroundColor = ConsoleColor.Green;
//                 Console.WriteLine("Writing File Success");
//                 Console.WriteLine("Press Enter To Exit");
//                 Console.ReadKey();
//                 Console.WriteLine("Exited Successfully");
//             }
//         }
//
//
//         /// <summary>
//         /// Generating Excel File
//         /// </summary>
//         /// <param name="entities"></param>
//         /// <param name="day"></param>
//         private static void GenerateLfsExcelFile(List<LfsSqlRecord> entities, DateTime day)
//         {
//             if (entities.Any())
//             {
//                 Console.ForegroundColor = ConsoleColor.DarkRed;
//                 Console.WriteLine($"Generating Excel File Starting From Day : {day.ToShortDateString()}...");
//                 using var workbook = new XLWorkbook();
//                 var worksheet = workbook.Worksheets.Add("Last Day");
//                 var currentRow = 1;
//                 var properties = entities.First().GetType().GetProperties();
//                 var columnNumber = 0;
//                 // set header columns
//                 foreach (var prop in properties)
//                 {
//                     worksheet.Cell(currentRow, ++columnNumber).Value = prop.Name;
//                 }
//
//                 foreach (var record in entities)
//                 {
//                     currentRow++;
//                     worksheet.Cell(currentRow, 1).Value = record.LNUMMER;
//                     worksheet.Cell(currentRow, 2).Value = record.DATUM;
//                     worksheet.Cell(currentRow, 3).Value = record.ZEIT;
//                     worksheet.Cell(currentRow, 4).Value = record.ZEIT2;
//                     worksheet.Cell(currentRow, 5).Value = record.KUNDE;
//                     worksheet.Cell(currentRow, 6).Value = record.HERKUNFT;
//                     worksheet.Cell(currentRow, 7).Value = record.FAHRZEUG;
//                     worksheet.Cell(currentRow, 8).Value = record.WNUMMER;
//                     worksheet.Cell(currentRow, 9).Value = record.WAEGER;
//                     worksheet.Cell(currentRow, 10).Value = record.BEMERKUNG;
//                     worksheet.Cell(currentRow, 11).Value = record.INFO;
//                     worksheet.Cell(currentRow, 12).Value = record.TYP;
//                     worksheet.Cell(currentRow, 13).Value = record.BRUTTO;
//                     worksheet.Cell(currentRow, 14).Value = record.TARA;
//                     worksheet.Cell(currentRow, 15).Value = record.NETTO;
//                     worksheet.Cell(currentRow, 16).Value = record.RECHNNR;
//                     worksheet.Cell(currentRow, 17).Value = record.PREIS;
//                     worksheet.Cell(currentRow, 18).Value = record.WNUM1;
//                     worksheet.Cell(currentRow, 19).Value = record.WNUM2;
//                     worksheet.Cell(currentRow, 20).Value = record.PREISPSCH;
//                     worksheet.Cell(currentRow, 21).Value = record.DATUM2;
//                     worksheet.Cell(currentRow, 22).Value = record.SPEDITION;
//                     worksheet.Cell(currentRow, 23).Value = record.KNDNAME;
//                     worksheet.Cell(currentRow, 24).Value = record.ORTNAME;
//                     worksheet.Cell(currentRow, 25).Value = record.ARTNAME;
//                     worksheet.Cell(currentRow, 26).Value = record.SPEDNAME;
//                     worksheet.Cell(currentRow, 27).Value = record.KNDNAME2;
//                     worksheet.Cell(currentRow, 28).Value = record.KNDSTR;
//                     worksheet.Cell(currentRow, 29).Value = record.KNDPLZ;
//                     worksheet.Cell(currentRow, 30).Value = record.KNDORT;
//                     worksheet.Cell(currentRow, 31).Value = record.ORTNAME2;
//                     worksheet.Cell(currentRow, 32).Value = record.ORTSTR;
//                     worksheet.Cell(currentRow, 33).Value = record.ORTPLZ;
//                     worksheet.Cell(currentRow, 34).Value = record.ORTORT;
//                     worksheet.Cell(currentRow, 35).Value = record.SPEDNAME2;
//                     worksheet.Cell(currentRow, 36).Value = record.SPEDSTR;
//                     worksheet.Cell(currentRow, 37).Value = record.SPEDPLZ;
//                     worksheet.Cell(currentRow, 38).Value = record.SPEDORT;
//                     worksheet.Cell(currentRow, 39).Value = record.ARTNAME2;
//                     worksheet.Cell(currentRow, 40).Value = record.BAR;
//                     worksheet.Cell(currentRow, 41).Value = record.DUMMY;
//                     worksheet.Cell(currentRow, 42).Value = record.FNUMMER;
//                     worksheet.Cell(currentRow, 43).Value = record.TRANSPORT;
//                     worksheet.Cell(currentRow, 44).Value = record.TRANSART;
//                     worksheet.Cell(currentRow, 45).Value = record.CONTAINER;
//                     worksheet.Cell(currentRow, 46).Value = record.CONTNAME;
//                     worksheet.Cell(currentRow, 47).Value = record.FAHRERNAME;
//                     worksheet.Cell(currentRow, 48).Value = record.FAHRER;
//                     worksheet.Cell(currentRow, 49).Value = record.AUFTRAG;
//                     worksheet.Cell(currentRow, 50).Value = record.REZEPT;
//                     worksheet.Cell(currentRow, 51).Value = record.REZEPTNAME;
//                     worksheet.Cell(currentRow, 52).Value = record.INFO1;
//                     worksheet.Cell(currentRow, 53).Value = record.ZELLE;
//                 }
//
//                 using var stream = new MemoryStream();
//                 workbook.SaveAs(stream);
//                 var content = stream.ToArray();
//                 var path = Configuration["ExcelPath"];
//                 Console.ForegroundColor = ConsoleColor.Yellow;
//                 Console.WriteLine($"Writing Excel File To Path {path}");
//                 bool exists = Directory.Exists(path);
//
//                 if (!exists)
//                     Directory.CreateDirectory(path);
//                 File.WriteAllBytes(path + "Lfs Last Day.xlsx", content);
//                 Console.ForegroundColor = ConsoleColor.Green;
//                 Console.WriteLine("Writing File Success");
//                 Console.WriteLine("Press Enter To Exit");
//                 Console.ReadKey();
//                 Console.WriteLine("Exited Successfully");
//             }
//         }
//         
//         
//         
//         /// <summary>
//         /// Getting Data For  Excel RBUCH
//         /// </summary>
//         /// <param name="day"></param>
//         /// <returns></returns>
//         private static List<RbuchSqlRecord> GetDataForRbuchExcel(DateTime day)
//         {
//             var connectionString = DbfFileDataReader.BuildConnectionString(_options);
//             var connection = new SqlConnection(connectionString);
//             var command = new SqlCommand($"select * from {_options.Table} where DATUM >= @yesterday");
//             command.Parameters.AddWithValue("@yesterday", day);
//             command.Connection = connection;
//             connection.Open();
//             using SqlDataReader dr = command.ExecuteReader();
//             var list = dr.MapToList<RbuchSqlRecord>();
//             Console.WriteLine(list.Count);
//             return list;
//         }
//
//         /// <summary>
//         /// Getting Excel Data
//         /// </summary>
//         /// <param name="day"></param>
//         /// <returns></returns>
//         private static List<LfsSqlRecord> GetDataForLfsExcel(DateTime day)
//         {
//             var connectionString = DbfFileDataReader.BuildConnectionString(_options);
//             var connection = new SqlConnection(connectionString);
//             var command = new SqlCommand($"select * from {_options.Table} where DATUM >= @yesterday");
//             command.Parameters.AddWithValue("@yesterday", day);
//             command.Connection = connection;
//             connection.Open();
//             using SqlDataReader dr = command.ExecuteReader();
//             var list = dr.MapToList<LfsSqlRecord>();
//             Console.WriteLine(list.Count);
//             return list;
//         }
//
//     }
//     
//     
// }