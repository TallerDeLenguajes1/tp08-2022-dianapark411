// See https://aka.ms/new-console-template for more information


Console.WriteLine("Ingrese la ruta de la carpeta");
string ruta = Console.ReadLine();
//ruta = Path.GetFullPath(ruta);
Console.WriteLine("Ruta: {0}", ruta);

List<string> archivos = new List<string>();

/*
Directory is a static class that provides static methods for working with directories. 
DirectoryInfo is an instance of a class that provides information about a specific directory.
*/

if(Directory.Exists(ruta)){
    archivos = Directory.GetFiles(ruta).ToList();

    if(archivos.Count == 0){
        Console.WriteLine("El directorio no contiene archivos");
    }
    else{
        foreach(string item in archivos){
            Console.WriteLine(item);
            Console.WriteLine($"Extensión: {Path.GetExtension(item)}");
        }
    }
    
}
else{
    Console.WriteLine("La ruta ingresada no existe");
}

Console.Write("\n");

FileStream fileStream;

if(!File.Exists(ruta + @"\index.csv")){
    Console.WriteLine("Creando archivo index.csv");
    fileStream = File.Create(ruta + @"\index.csv");
    fileStream.Close();
}

for(int i = 0; i < archivos.Count; i++){
    archivos[i] = Path.GetFileName(archivos[i]);
}


var archivo = new FileStream(ruta + @"\index.csv", FileMode.Truncate);
string cadena = "";

cadena = "ID;NOMBRE;EXTENSION\n";
for(int i = 0; i < archivos.Count; i++){
    cadena += $"{i + 1};{Path.GetFileNameWithoutExtension(archivos[i])};{Path.GetExtension(archivos[i])}\n";
}

StreamWriter escribir = new StreamWriter(archivo);

escribir.Write(cadena);
escribir.Close();
archivo.Close();