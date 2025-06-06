# WeatherApi

All URIs are relative to *http://localhost*

|Method | HTTP request | Description|
|------------- | ------------- | -------------|
|[**weatherGet**](#weatherget) | **GET** /Weather | |
|[**weatherPost**](#weatherpost) | **POST** /Weather | |

# **weatherGet**
> Array<WeatherData> weatherGet()


### Example

```typescript
import {
    WeatherApi,
    Configuration
} from './api';

const configuration = new Configuration();
const apiInstance = new WeatherApi(configuration);

const { status, data } = await apiInstance.weatherGet();
```

### Parameters
This endpoint does not have any parameters.


### Return type

**Array<WeatherData>**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
|**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

# **weatherPost**
> WeatherData weatherPost()


### Example

```typescript
import {
    WeatherApi,
    Configuration,
    WeatherData
} from './api';

const configuration = new Configuration();
const apiInstance = new WeatherApi(configuration);

let weatherData: WeatherData; // (optional)

const { status, data } = await apiInstance.weatherPost(
    weatherData
);
```

### Parameters

|Name | Type | Description  | Notes|
|------------- | ------------- | ------------- | -------------|
| **weatherData** | **WeatherData**|  | |


### Return type

**WeatherData**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, application/*+json
 - **Accept**: text/plain, application/json, text/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
|**200** | OK |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

