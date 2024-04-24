
using Microsoft.EntityFrameworkCore;

var app = new AppDbContext();

 var data = app.Vendor.Where(tt => EF.Functions.Like(tt.VendorID, ""));

Console.WriteLine(data.VendorID);
