using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public enum EnumPol
    {
        MUSKO,
        ZENSKO,
    }

    public enum EnumUloga
    {
        MUSTERIJA,
        VOZAC,
        DISPECER,
    }

    public enum EnumAutomobil
    {
        PUTNICKI,
        KOMBI,
    }

    public enum EnumStatus
    {
        KREIRANA,
        FORMIRANA,
        OBRADJENA,
        PRIHVAĆENA,
        OTKAZANA,
        NEUSPESNA,
        USPESNA,
    }
}
