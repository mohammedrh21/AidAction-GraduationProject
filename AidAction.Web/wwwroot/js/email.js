<script type="module">
    import {initializeApp} from "https://www.gstatic.com/firebasejs/11.6.1/firebase-app.js";
    import {getAuth, sendPasswordResetEmail, sendEmailVerification} from "https://www.gstatic.com/firebasejs/11.6.1/firebase-auth.js";

    const firebaseConfig = {
        apiKey: "AIzaSyBV22COoFG9bOu4pt6DCpe9KgmFSf2FU-c",
    authDomain: "aid-action-platform.firebaseapp.com",
    projectId: "aid-action-platform",
    storageBucket: "aid-action-platform.appspot.com",
    messagingSenderId: "5780799433",
    appId: "1:5780799433:web:18dfff319045af956b7218",
    measurementId: "G-3BXNDDR5K7"
  };

    const app = initializeApp(firebaseConfig);
    const auth = getAuth(app);

    window.firebaseFunctions = {
        sendResetEmail: async function (email) {
      try {
        await sendPasswordResetEmail(auth, email);
    return "Password reset email sent!";
      } catch (error) {
        return error.message;
      }
    },
    sendVerificationEmail: async function () {
      try {
        const user = auth.currentUser;
    if (user) {
        await sendEmailVerification(user);
    return "Verification email sent!";
        } else {
          return "No user is signed in.";
        }
      } catch (error) {
        return error.message;
      }
    }
  };
</script>
