﻿using System.Collections.Generic;

namespace FasTnT.Domain.Queries.GetQueryNames
{
    public record GetQueryNamesResult(IEnumerable<string> QueryNames);
}