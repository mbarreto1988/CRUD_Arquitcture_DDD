﻿using System;
using System.Collections.Generic;

namespace User_1.Domain.Entities;

public class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public string? Dni { get; set; }
}
