<script lang="ts">
import { defineComponent } from 'vue';
import WeatherComponent from './components/WeatherComponent.vue';

export default defineComponent({
  name: 'App',
  components: {
    WeatherComponent
  }
})
</script>

<template>
  <div>
    <WeatherComponent />
  </div>
</template>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
