using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvironmentRepository.Enums
{
    public enum Status
    {
        Pasif,
        Aktif
    }

    public enum Cinsiyet
    {
        Kadin,
        Erkek
    }

    public enum MusteriRiskDurumu
    {
        Risksiz,
        Riskli,
    }

    public enum KontakIliskiDurumu
    {
        CokOlumsuz,
        Olumsuz,
        Normal,
        Olumlu,
        CokOlumlu
    }
}
