using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

public partial class MainViewModel : ObservableObject
{
    private const double PrecioProducto1 = 100.00;
    private const double PrecioProducto2 = 200.00;
    private const double PrecioProducto3 = 300.00;

    [ObservableProperty]
    private string cantidadProducto1;

    [ObservableProperty]
    private string cantidadProducto2;

    [ObservableProperty]
    private string cantidadProducto3;

    [ObservableProperty]
    private string subtotal;

    [ObservableProperty]
    private string descuento;

    [ObservableProperty]
    private string total;

    public MainViewModel()
    {
        Limpiar();
    }

    [RelayCommand]
    void Calcular()
    {
        
        int cantidad1 = string.IsNullOrWhiteSpace(CantidadProducto1) ? 0 : int.Parse(CantidadProducto1);
        int cantidad2 = string.IsNullOrWhiteSpace(CantidadProducto2) ? 0 : int.Parse(CantidadProducto2);
        int cantidad3 = string.IsNullOrWhiteSpace(CantidadProducto3) ? 0 : int.Parse(CantidadProducto3);

        
        double subtotalValue = (cantidad1 * PrecioProducto1) +
                               (cantidad2 * PrecioProducto2) +
                               (cantidad3 * PrecioProducto3);

        Subtotal = FormatearMoneda(subtotalValue);


        double descuentoValue = 0;
        if (subtotalValue >= 10000)
            descuentoValue = 0.30;
        else if (subtotalValue >= 5000)
            descuentoValue = 0.20;
        else if (subtotalValue >= 1000)
            descuentoValue = 0.10;

        Descuento = (descuentoValue * 100).ToString("F0") + "%";
        Total = FormatearMoneda(subtotalValue - (subtotalValue * descuentoValue));
    }

    [RelayCommand]
    void Limpiar()
    {
        CantidadProducto1 = string.Empty;
        CantidadProducto2 = string.Empty;
        CantidadProducto3 = string.Empty;
        Subtotal = string.Empty;
        Descuento = string.Empty;
        Total = string.Empty;
    }
    private string FormatearMoneda(double valor)
    {
        return $"L{valor:N2}";
    }
}