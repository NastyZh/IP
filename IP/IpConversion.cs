using System.Net;

namespace IP;

public class IpConversion
{
    public IPAddress GetIpAddress(string address)
    {
        IPAddress ipAddress = IPAddress.Parse(address);
        return ipAddress.MapToIPv4();
    }
    public IPAddress GetUpperBoundAddress(IPAddress addressStart, IPAddress addressMask)
    {
        byte[] lowerBoundBytes = addressStart.GetAddressBytes();
        byte[] subnetMaskBytes = addressMask.GetAddressBytes();

        // Применяю маску подсети к каждому байту нижней границы диапазона
        byte[] upperBoundBytes = new byte[lowerBoundBytes.Length];
        for (int i = 0; i < lowerBoundBytes.Length; i++)
        {
            upperBoundBytes[i] = (byte)(lowerBoundBytes[i] | ~subnetMaskBytes[i]);
        }

        return new IPAddress(upperBoundBytes);
    }
}