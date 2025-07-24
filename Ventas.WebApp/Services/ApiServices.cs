using Ventas.WebApp.Models;

namespace Ventas.WebApp.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public ApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiBaseUrl = configuration["ApiSettings:BaseUrl"] ?? throw new ArgumentNullException("ApiSettings:BaseUrl no configurado en appsettings.json");
            _httpClient.BaseAddress = new Uri(_apiBaseUrl); // Set base address
        }

        #region Ventas
        public async Task<List<VentaViewModel>> GetAllVentasAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Ventas");
                response.EnsureSuccessStatusCode(); // Throws an exception if the HTTP response status is an error code
                return await response.Content.ReadFromJsonAsync<List<VentaViewModel>>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al obtener todas las ventas: {ex.Message}");
                return new List<VentaViewModel>(); // Return empty list on error
            }
        }

        public async Task<VentaViewModel> GetVentaByCodigoAsync(string codigo)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Ventas/{codigo}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<VentaViewModel>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al obtener venta por código '{codigo}': {ex.Message}");
                return null;
            }
        }

        public async Task<bool> CreateVentaAsync(VentaViewModel venta)
        {
            HttpResponseMessage response = null;

            try
            {
                 response = await _httpClient.PostAsJsonAsync("api/Ventas", venta);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al crear venta: {ex.Message}");
                if (response != null)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"API Error Content: {errorContent}");
                }
                return false;
            }
        }

        public async Task<bool> UpdateVentaAsync(string codigo, VentaViewModel venta)
        {
            HttpResponseMessage response = null;

            try
            {
                response = await _httpClient.PutAsJsonAsync($"api/Ventas/{codigo}", venta);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al actualizar venta con código '{codigo}': {ex.Message}");
                if (response != null)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"API Error Content: {errorContent}");
                }
                return false;
            }
        }

        public async Task<bool> DeleteVentaAsync(string codigo)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Ventas/{codigo}");
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al eliminar venta con código '{codigo}': {ex.Message}");
                return false;
            }
        }
        #endregion

        #region Clientes
        public async Task<List<ClienteViewModel>> GetAllClientesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Clientes");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<List<ClienteViewModel>>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al obtener clientes: {ex.Message}");
                return new List<ClienteViewModel>();
            }
        }

        public async Task<bool> CreateClienteAsync(RegistrarClienteViewModel clienteDto)
        {
            HttpResponseMessage response = null;

            try
            {
                response = await _httpClient.PostAsJsonAsync("api/Clientes", clienteDto);
                response.EnsureSuccessStatusCode(); // Lanza excepción si el código de estado HTTP no es 2xx
                return true;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al crear cliente: {ex.Message}");
                // Puedes loguear más detalles de la respuesta de la API aquí para depuración
                if (ex.StatusCode != null) Console.WriteLine($"HTTP Status Code: {ex.StatusCode}");
                var errorContent = ex.Data.Contains("ResponseContent") ? ex.Data["ResponseContent"] 
                                    : await (response?.Content.ReadAsStringAsync() ?? Task.FromResult("No content"));
                Console.WriteLine($"API Error Content: {errorContent}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción inesperada al crear cliente: {ex.Message}");
                return false;
            }
        }
        #endregion


        #region Punto de ventas
        public async Task<List<PuntoDeVentaViewModel>> GetAllPuntosDeVentaAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/PuntosDeVenta");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<List<PuntoDeVentaViewModel>>();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al obtener puntos de venta: {ex.Message}");
                return new List<PuntoDeVentaViewModel>();
            }
        }
        #endregion

    }
}
