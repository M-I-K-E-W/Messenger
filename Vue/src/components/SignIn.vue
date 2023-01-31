<template>

    <h1>Sign in</h1>

    <table class="signin">
        <thead>
            <tr>
                <td>Username</td>
                <td><input type="text" name="userName" /></td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>Password</td>
                <td><input type="password" name="password" /></td>
            </tr>
        </tbody>
    </table>

    <p><router-link to="/messages">Temporary link to messages until sign in is developed</router-link></p>

</template>

<script>
export default {
  name: 'SignIn',
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    .signin {
        padding: 5px;
    }
</style>