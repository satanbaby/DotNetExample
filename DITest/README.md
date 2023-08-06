# asp.net core DI 生命週期

```csharp
builder.Services.AddScoped<Person>();
builder.Services.AddScoped<Taiwanese>();
builder.Services.AddSingleton<PersonOnSingleton>();
```
### 每次呼叫 API，都只會建構有使用到的服務，已註冊沒使用到的不會被建構
```http request
### 呼叫後只建構 Person，重複呼叫重複建構
GET https://localhost:7182/person
```

```http request
### 呼叫後只建構 Taiwanese，重複呼叫重複建構
GET https://localhost:7182/taiwanese
```

### Singleton 在應用程式運行時期並不會被建構，只有在有使用到時才會建構，重複呼叫不會重複建構
```http request
### 以上兩次呼叫都不會建構 PersonOnSingleton
# 只有該API被呼叫才會建構 PersonOnSingleton，且重複呼叫並不會重複建構
GET https://localhost:7182/persononsingleton
```
