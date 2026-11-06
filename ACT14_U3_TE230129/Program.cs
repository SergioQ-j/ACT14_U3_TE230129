using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("SISTEMA DE MONITOREO DE SENSORES INDUSTRIALES");
        Console.WriteLine();

        // 1. SENSOR DE TEMPERATURA
        Console.WriteLine("--- REGISTRO DE SENSOR DE TEMPERATURA ---");
        SensorTemperatura sensorTemp = new SensorTemperatura();

        Console.Write("Ingrese el identificador del sensor: ");
        sensorTemp.Identificador = Console.ReadLine() ?? "Sin identificador";

        Console.Write("Ingrese la temperatura medida en °C: ");
        sensorTemp.Valormedio = Convert.ToDouble(Console.ReadLine() ?? "0");

        Console.Write("¿El sensor está activo? (si/no): ");
        string respTemp = (Console.ReadLine() ?? "").Trim().ToLower();
        sensorTemp.Activo = (respTemp == "si" || respTemp == "sí" || respTemp == "s");

        Console.WriteLine();
        sensorTemp.MostrarDatos();
        Console.WriteLine($"Evaluación: {sensorTemp.EvaluarTemperatura()}");
        Console.WriteLine();


        // 2. SENSOR DE PRESIÓN
        Console.WriteLine("--- REGISTRO DE SENSOR DE PRESIÓN ---");
        SensorPresion sensorPres = new SensorPresion();

        Console.Write("Ingrese el identificador del sensor: ");
        sensorPres.Identificador = Console.ReadLine() ?? "Sin identificador";

        Console.Write("Ingrese la presión medida en bar: ");
        sensorPres.Valormedio = Convert.ToDouble(Console.ReadLine() ?? "0");

        Console.Write("¿El sensor está activo? (si/no): ");
        string respPres = (Console.ReadLine() ?? "").Trim().ToLower();
        sensorPres.Activo = (respPres == "si" || respPres == "sí" || respPres == "s");

        Console.WriteLine();
        sensorPres.MostrarDatos();
        Console.WriteLine($"Evaluación: {sensorPres.EvaluarPresion()}");
        Console.WriteLine();


        // 3. SENSOR DE DISTANCIA
        Console.WriteLine("--- REGISTRO DE SENSOR DE DISTANCIA ---");
        SensorDistancia sensorDist = new SensorDistancia();

        Console.Write("Ingrese el identificador del sensor: ");
        sensorDist.Identificador = Console.ReadLine() ?? "Sin identificador";

        Console.Write("Ingrese la distancia medida en cm: ");
        sensorDist.Valormedio = Convert.ToDouble(Console.ReadLine() ?? "0");

        Console.Write("¿El sensor está activo? (si/no): ");
        string respDist = (Console.ReadLine() ?? "").Trim().ToLower();
        sensorDist.Activo = (respDist == "si" || respDist == "sí" || respDist == "s");

        Console.WriteLine();
        sensorDist.MostrarDatos();
        Console.WriteLine($"Evaluación: {sensorDist.EvaluarDistancia()}");
    }
}


// CLASE BASE
class Sensor
{
    // Propiedades comunes con inicialización anti-nulos
    public string Identificador { get; set; } = string.Empty;
    public double Valormedio { get; set; }
    public bool Activo { get; set; }

    // Método para determinar el estado
    public string ObtenerEstado()
    {
        if (Activo)
            return "Sensor en funcionamiento";
        else
            return "Sensor apagado / Falla";
    }

    // Método para mostrar datos generales
    public void MostrarDatos()
    {
        Console.WriteLine("DATOS DEL SENSOR");
        Console.WriteLine($"Identificador: {Identificador}");
        Console.WriteLine($"Valor Medido: {Valormedio}");
        Console.WriteLine($"Estado: {ObtenerEstado()}");
    }
}


// CLASES DERIVADAS

// Clase derivada para temperatura
class SensorTemperatura : Sensor
{
    // Método propio para evaluar la condición (> 80 °C)
    public string EvaluarTemperatura()
    {
        if (Valormedio > 80)
            return "ALERTA: Supera el límite de 80°C. Requiere atención.";

        return "Medición dentro del criterio establecido.";
    }
}

// Clase derivada para presión
class SensorPresion : Sensor
{
    // Método propio para evaluar la condición (> 10 bar)
    public string EvaluarPresion()
    {
        if (Valormedio > 10)
            return "ALERTA: Supera el límite de 10 bar. Requiere atención.";

        return "Medición dentro del criterio establecido.";
    }
}

// Clase derivada para distancia
class SensorDistancia : Sensor
{
    // Método propio para evaluar la condición (> 20 cm)
    public string EvaluarDistancia()
    {
        if (Valormedio > 20)
            return "ALERTA: Supera el límite de 20 cm. Requiere atención.";

        return "Medición dentro del criterio establecido.";
    }
}
