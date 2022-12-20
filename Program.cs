using QrCodeGenerator;

try
{
    /*
    string texto = args[0];
    string caminho = args[1];
    int largura = int.Parse(args[2]);
    int altura = int.Parse(args[2]);
    */

    string texto = "teste";
    string caminho = @"C:\Development\QrCodeGenerator\teste1.bmp";
    int largura = 150;
    int altura = 150;
    
    var dir = Path.GetDirectoryName(caminho);
    if (!Directory.Exists(dir))
        Directory.CreateDirectory(dir);

    texto = texto.Replace('#', ' ');
    var qrCode = Service.GerarQRCodeDataMatrix(texto, largura, altura);
    
    Service.SaveBitmap(caminho, 100,100,qrCode);
    
}
catch (Exception ex)
{
    throw new Exception($"Erro na criação do QrCode - {ex.Message}");
}
