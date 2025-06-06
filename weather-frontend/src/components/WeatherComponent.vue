<template>
  <div class="weather-container">
    <h2>Weather Data</h2>
    
    <!-- Form to add weather data -->
    <div class="add-weather">
      <h3>Add Weather Data</h3>
      <form @submit.prevent="addWeatherData">
        <div class="form-group">
          <label>Temperature (°C):</label>
          <input v-model.number="newWeather.temperatureC" type="number" required />
        </div>
        <div class="form-group">
          <label>Summary:</label>
          <input v-model="newWeather.summary" type="text" required />
        </div>
        <button type="submit">Add Weather Data</button>
      </form>
    </div>

    <!-- Display weather data -->
    <div class="weather-list">
      <h3>Weather Records</h3>
      <div v-if="weatherData.length === 0" class="no-data">
        No weather data available
      </div>
      <div v-else class="weather-grid">
        <div v-for="(weather, index) in weatherData" :key="index" class="weather-card">
          <p>Date: {{ new Date(weather.date).toLocaleDateString() }}</p>
          <p>Temperature: {{ weather.temperatureC }}°C / {{ weather.temperatureF }}°F</p>
          <p>Summary: {{ weather.summary }}</p>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, onMounted, ref } from 'vue'
import { Configuration, WeatherApi, WeatherData } from '../generated/api'

// Create API client instance
const apiClient = new WeatherApi(
  new Configuration({
    basePath: 'http://localhost:5258',
  })
)

export default defineComponent({
  name: 'WeatherComponent',
  setup() {
    const weatherData = ref<WeatherData[]>([])
    const newWeather = ref({
      temperatureC: 0,
      summary: ''
    })

    const fetchWeatherData = async () => {
      try {
        const response = await apiClient.weatherGet()
        weatherData.value = response.data
      } catch (error) {
        console.error('Error fetching weather data:', error)
      }
    }

    const addWeatherData = async () => {
      try {
        const weatherPayload: WeatherData = {
          date: new Date().toISOString(),
          temperatureC: newWeather.value.temperatureC,
          summary: newWeather.value.summary
        }
        
        await apiClient.weatherPost(weatherPayload)
        await fetchWeatherData()
        
        // Reset form
        newWeather.value.temperatureC = 0
        newWeather.value.summary = ''
      } catch (error) {
        console.error('Error adding weather data:', error)
      }
    }

    onMounted(() => {
      fetchWeatherData()
    })

    return {
      weatherData,
      newWeather,
      addWeatherData
    }
  }
})
</script>

<style scoped>
.weather-container {
  max-width: 800px;
  margin: 0 auto;
  padding: 20px;
}

.add-weather {
  margin-bottom: 30px;
  padding: 20px;
  background-color: #f5f5f5;
  border-radius: 8px;
}

.form-group {
  margin-bottom: 15px;
}

.form-group label {
  display: block;
  margin-bottom: 5px;
}

input {
  width: 100%;
  padding: 8px;
  border: 1px solid #ddd;
  border-radius: 4px;
}

button {
  background-color: #4CAF50;
  color: white;
  padding: 10px 20px;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

button:hover {
  background-color: #45a049;
}

.weather-grid {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(250px, 1fr));
  gap: 20px;
}

.weather-card {
  background-color: #fff;
  padding: 15px;
  border-radius: 8px;
  box-shadow: 0 2px 4px rgba(0,0,0,0.1);
}

.no-data {
  text-align: center;
  padding: 20px;
  background-color: #f5f5f5;
  border-radius: 8px;
}
</style> 