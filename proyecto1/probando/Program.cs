using System.Text.Json;

const string settingsFile = "appsettings.json";

if (!File.Exists(settingsFile))
{
	Console.WriteLine($"No se encontró {settingsFile}.");
	return;
}

using var settingsDocument = JsonDocument.Parse(File.ReadAllText(settingsFile));
var connectionString = settingsDocument.RootElement
	.GetProperty("ConnectionStrings")
	.GetProperty("DefaultConnection")
	.GetString();

if (string.IsNullOrWhiteSpace(connectionString))
{
	Console.WriteLine("La cadena de conexión no está configurada.");
	return;
}

Console.WriteLine("Simulación de cadena de conexión");
Console.WriteLine($"Configuración: {MaskPassword(connectionString)}");
Console.WriteLine("[1/4] Abriendo conexión...");
Console.WriteLine("[2/4] Conexión establecida.");
Console.WriteLine("[3/4] Ejecutando consulta de prueba: SELECT 1");
Console.WriteLine("[4/4] Consulta completada. Conexión cerrada.");

static string MaskPassword(string connectionString)
{
	return System.Text.RegularExpressions.Regex.Replace(
		connectionString,
		"(?i)(Password\\s*=\\s*)[^;]*",
		"$1***");
}

string strype_api_key="sk_test_4eC39HqLyjWDarjtT1zdp7dc";
