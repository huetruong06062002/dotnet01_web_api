var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Thêm service controllers
builder.Services.AddControllers();

//Cho phép các domain client được gửi dữ liệu (Post, Put, Delete)
builder.Services.AddCors(option =>{
    option.AddPolicy("allow_origin", policy => {
        // policy.AllowAnyOrigin(); //Cho phép tất cả các clients đều có thể gửi dữ liệu đến server
        policy.WithOrigins("http://localhost:5002", "https://login.cybersoft.edu.vn")
        .AllowAnyHeader() //Cho phép rq tất cả header 
        .AllowAnyMethod() // Cho phép rq tất cả method(GET, POST, PUT, DELETE)
        .AllowCredentials(); //CHo phép cookie...
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



//map các route controller vào swagger
app.MapControllers();

app.UseHttpsRedirection();
app.Run();

