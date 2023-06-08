using System.IO;
using System.Linq;
using ClosedXML.Excel;

public class ExcelService
{
    public byte[] GenerateExcel<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
    {
        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("Sheet1");

            // Agrega las cabeceras de las columnas
            var properties = typeof(TEntity).GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                worksheet.Cell(1, i + 1).Value = properties[i].Name;
            }

            // Agrega los datos de las entidades
            var data = entities.ToList();
            for (int row = 0; row < data.Count; row++)
            {
                for (int col = 0; col < properties.Length; col++)
                {
                    worksheet.Cell(row + 2, col + 1).Value = properties[col].GetValue(data[row])?.ToString();
                }
            }

            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                return stream.ToArray();
            }
        }
    }
}
