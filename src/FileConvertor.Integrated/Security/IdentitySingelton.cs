﻿namespace FileConvertor.Integrated.Security;

public class IdentitySingelton
{
    private static IdentitySingelton _identitySingelton;

    public string Token { get; set; }
    public string Name { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string Region { get; set; }
    public string ImagePath { get; set; }
    public string HospitalName { get; set; }

    private IdentitySingelton()
    {
    }

    public static IdentitySingelton GetInstance()
    {
        if (_identitySingelton is null)
            _identitySingelton = new IdentitySingelton();
        return _identitySingelton;

    }
}
