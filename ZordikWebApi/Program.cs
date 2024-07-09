using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Setup.BL.User.address;
using Setup.BL.User.auth;
using Setup.BL.User.banner;
using Setup.BL.User.cart;
using Setup.BL.User.order;
using Setup.BL.User.product;
using Setup.BL.User.productFeatures;
using Setup.BL.User.review;
using Setup.BL.User.wishlist;
using Setup.ITF.User.address;
using Setup.ITF.User.auth;
using Setup.ITF.User.banner;
using Setup.ITF.User.cart;
using Setup.ITF.User.order;
using Setup.ITF.User.product;
using Setup.ITF.User.productFeatures;
using Setup.ITF.User.review;
using Setup.ITF.User.wishlist;
using System.Text;
using Microsoft.AspNetCore.HttpOverrides;
using Setup.ITF.Admin.auth;
using Setup.BL.Admin.auth;
using Setup.ITF.Admin.category;
using Setup.BL.Admin.category;
using Setup.ITF.Admin.common;
using Setup.BL.Admin.common;
using Setup.ITF.Admin.sub_category;
using Setup.BL.Admin.sub_category;
using Setup.ITF.Admin.product.color;
using Setup.BL.Admin.product.color;
using Setup.ITF.Admin.product.size;
using Setup.BL.Admin.product.size;
using Setup.ITF.Admin.product;
using Setup.BL.Admin.product;
using Setup.ITF.Admin.product.variation;
using Setup.BL.Admin.product.variation;
using Setup.ITF.Admin.order;
using Setup.BL.Admin.order;
using Setup.ITF.Admin.coupon;
using Setup.BL.Admin.coupon;
using Setup.ITF.Admin.brand;
using Setup.BL.Admin.brand;
using Setup.ITF.Admin.about;
using Setup.BL.Admin.about;
using Setup.BL.Admin.contact;
using Setup.ITF.Admin.contact;
using Setup.ITF.Admin.company_detail;
using Setup.BL.Admin.company_detail;
using Setup.BL.Admin.product.ToggleProductFeature;
using Setup.ITF.Admin.product.ToggleProductFeature;
using Setup.BL.Admin.product.product_image;
using Setup.ITF.Admin.product.product_image;
using Setup.BL.Admin.blog;
using Setup.ITF.Admin.blog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region Add Services for API
/********************* Website *********************************/
// Address
builder.Services.AddScoped<IAddressAdd, AddressAdd>();
builder.Services.AddScoped<IAddressDelete, AddressDelete>();
builder.Services.AddScoped<IAddressSelect, AddressSelect>();
builder.Services.AddScoped<IAddressUpdate, AddressUpdate>();

// Auth
builder.Services.AddScoped<IContactForm, ContactForm>();
builder.Services.AddScoped<ICreateAccount, CreateAccount>();
builder.Services.AddScoped<ILogin, Login>();
builder.Services.AddScoped<IForgotUserPassword, ForgotUserPassword>();
builder.Services.AddScoped<IUpdateUserPassword, UpdateUserPassword>();

// Banner
builder.Services.AddScoped<IHomeBanner, HomeBanner>();

// Cart
builder.Services.AddScoped<IAddCart, AddCart>();
builder.Services.AddScoped<IDeleteCart, DeleteCart>();
builder.Services.AddScoped<IGetCart, GetCart>();
builder.Services.AddScoped<IUpdateCart, UpdateCart>();

// Order
builder.Services.AddScoped<ICancelOrder, CancelOrder>();
builder.Services.AddScoped<ICreateOrder, CreateOrder>();
builder.Services.AddScoped<ISelectOrder, SelectOrder>();
builder.Services.AddScoped<IOrderStatus, OrderStatus>();
builder.Services.AddScoped<IUserActivity, UserActivity>();

// product
builder.Services.AddScoped<IAllProduct, AllProduct>();
builder.Services.AddScoped<IproductByCategory, ProductByCategory>();
builder.Services.AddScoped<IProductById, ProductById>();
builder.Services.AddScoped<IProductBySubcategory, ProductBySubCategory>();
builder.Services.AddScoped<IProductByTag, ProductByTag>();

// product feature
builder.Services.AddScoped<ICategory, Category>();
builder.Services.AddScoped<IColor, Color>();
builder.Services.AddScoped<ISize, Size>();
builder.Services.AddScoped<ISubCategory, SubCategory>();

// review
builder.Services.AddScoped<IAddReview, AddReview>();
builder.Services.AddScoped<IGetReview, GetReview>();
builder.Services.AddScoped<ITestimonial, Testimonial>();
// wishlist
builder.Services.AddScoped<IAddWishlist, AddWishlist>();
builder.Services.AddScoped<IDeleteWishlist, DeleteWishlist>();
builder.Services.AddScoped<IGetWishlist, GetWishlist>();


/********************* Admin *********************************/
//Common
builder.Services.AddScoped<ISwitchStatus, SwitchStatus>();
builder.Services.AddScoped<IRecordDelete, RecordDelete>();

// auth 
builder.Services.AddScoped<IAdminLogin, AdminLogin>();
builder.Services.AddScoped<IForgotPassword, ForgotPassword>();
builder.Services.AddScoped<IUpdatePassword, UpdatePassword>();

// Category
builder.Services.AddScoped<IGetCategory, GetCategory>();
builder.Services.AddScoped<IAddCategory, AddCategory>();
builder.Services.AddScoped<ICategoryUpdate, CategoryUpdate>();
builder.Services.AddScoped<ICategoryDelete, CategoryDelete>();

// Sub Category
builder.Services.AddScoped<IGetSubCategory, GetSubCategory>();
builder.Services.AddScoped<IAddSubCategory, AddSubCategory>();
builder.Services.AddScoped<ISubCategoryUpdate, SubCategoryUpdate>();
builder.Services.AddScoped<ISubCategoryDelete, SubCategoryDelete>();

// color
builder.Services.AddScoped<IAddColor, AddColor>();
builder.Services.AddScoped<IColorUpdate, ColorUpdate>();
builder.Services.AddScoped<IGetColor, GetColor>();
builder.Services.AddScoped<IColorDelete, ColorDelete>();

// size
builder.Services.AddScoped<IAddSize, AddSize>();
builder.Services.AddScoped<IGetSize, GetSize>();
builder.Services.AddScoped<ISizeUpdate, SizeUpdate>();
builder.Services.AddScoped<ISizeDelete, SizeDelete>();

// Product
builder.Services.AddScoped<IGetProduct, GetProduct>();
builder.Services.AddScoped<IAddProduct, AddProduct>();
builder.Services.AddScoped<IProductUpdate, ProductUpdate>();
builder.Services.AddScoped<IProductDelete, ProductDelete>();

// Product Image
builder.Services.AddScoped<IProductImageDelete, ProductImageDelete>();

// Variation
builder.Services.AddScoped<IGetVariation, GetVariation>();
builder.Services.AddScoped<IAddVariation, AddVariation>();
builder.Services.AddScoped<IVariationUpdate, VariationUpdate>();
builder.Services.AddScoped<IVariationDelete, VariationDelete>();

// Order
builder.Services.AddScoped<IGetOrder, GetOrder>();
builder.Services.AddScoped<IOrderUpdate, OrderUpdate>();
builder.Services.AddScoped<IOrderDelete, OrderDelete>();

// Brand
builder.Services.AddScoped<IAddBrand, AddBrand>();
builder.Services.AddScoped<IGetBrand, GetBrand>();
builder.Services.AddScoped<IBrandUpdate, BrandUpdate>();
builder.Services.AddScoped<IBrandDelete, BrandDelete>();

// About
builder.Services.AddScoped<IAddAbout, AddAbout>();
builder.Services.AddScoped<IGetAbout, GetAbout>();
builder.Services.AddScoped<IAboutUpdate, AboutUpdate>();
builder.Services.AddScoped<IAboutDelete, AboutDelete>();

// Coupon
builder.Services.AddScoped<IAddCoupon, AddCoupon>();
builder.Services.AddScoped<IAddCoupon, AddCoupon>();
builder.Services.AddScoped<ICouponUpdate, CouponUpdate>();
builder.Services.AddScoped<ICouponDelete, CouponDelete>();

// Contact
builder.Services.AddScoped<IAddContact, AddContact>();
builder.Services.AddScoped<IGetContact, GetContact>();
builder.Services.AddScoped<IContactUpdate, ContactUpdate>();
builder.Services.AddScoped<IContactDelete, ContactDelete>();

// Company Detail
builder.Services.AddScoped<IAddCompanyDetail, AddCompanyDetail>();
builder.Services.AddScoped<IGetCompanyDetail, GetCompanyDetail>();
builder.Services.AddScoped<ICompanyDetailUpdate, CompanyDetailUpdate>();
builder.Services.AddScoped<ICompanyDetailDelete, CompanyDetailDelete>();

// ToggleUpdate
builder.Services.AddScoped<ISingleToggleUpdate, SingleToggleUpdate>();
builder.Services.AddScoped<IBulkToggleUpdate, BulkToggleUpdate>();



// Blog Category
builder.Services.AddScoped<IAddBlog, AddBlog>();
builder.Services.AddScoped<IBlogUpdate, BlogUpdate>();
builder.Services.AddScoped<IGetBlog, GetBlog>();
builder.Services.AddScoped<IBlogDelete, BlogDelete>();

#endregion



// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});



builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAuthorization();

// Add configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "jwtToken_Auth_API",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "Jwt",
        In = ParameterLocation.Header,
        Description = "Enter Jwt Token With Bearer Format like bearer[space] token"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>()
        }
    });
});


//builder.Services.Configure<ForwardedHeadersOptions>(options =>
//{
//    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
//});

var app = builder.Build();

//app.UseForwardedHeaders();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();


// Use CORS before authentication and authorization
app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.UseStaticFiles();

IConfiguration configuration = app.Configuration;

IWebHostEnvironment environment = app.Environment;

app.MapControllers();

app.Run();
