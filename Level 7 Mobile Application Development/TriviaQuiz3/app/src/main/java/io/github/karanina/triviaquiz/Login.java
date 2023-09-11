package io.github.karanina.triviaquiz;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.os.Parcelable;
import android.text.TextUtils;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.auth.AuthResult;
import com.google.firebase.auth.FirebaseAuth;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.ValueEventListener;

import java.io.Serializable;
import java.util.ArrayList;

import io.github.karanina.triviaquiz.model.User;

public class Login extends AppCompatActivity implements View.OnClickListener {
    TextView et_email, et_password;
    Button btn_login, btn_register;
    String email, password, userID, accessLevel;
    FirebaseAuth firebaseAuth;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        et_email = findViewById(R.id.et_emailAddress);
        et_password = findViewById(R.id.et_password);
        btn_login = findViewById(R.id.btn_login);
        btn_register = findViewById(R.id.btn_register);


        email = et_email.getText().toString();
        password = et_password.getText().toString();

        btn_login.setOnClickListener(this);
        btn_register.setOnClickListener(this);


        firebaseAuth = FirebaseAuth.getInstance();
    }

    @Override
    public void onClick(View view) {
        if (view.getId() == btn_login.getId()){
            loginUser();
        }
        else if (view.getId() == btn_register.getId()){
            Intent intent = new Intent();
            intent.putExtra("accessLevel", "Player");
            intent.setClass(this, Registration.class);
            startActivity(intent);
        }

    }

    private void loginUser() {
        String email = et_email.getText().toString();
        String password = et_password.getText().toString();

        // if no email is passed in, show error message.
        if (TextUtils.isEmpty(email)){
            et_email.setError("Email address is required");
            et_email.requestFocus();
        }
        else if (TextUtils.isEmpty(password)){
            et_password.setError("Password is require");
            et_password.requestFocus();
        }
        else {
            firebaseAuth.signInWithEmailAndPassword(email, password).addOnCompleteListener(new OnCompleteListener<AuthResult>() {
                @Override
                public void onComplete(@NonNull Task<AuthResult> task) {
                    if (task.isSuccessful()){
                        Toast.makeText(Login.this,
                                "User logged in successfully.", Toast.LENGTH_SHORT).show();
                        String authKey = firebaseAuth.getCurrentUser().getUid();
                        getUser(authKey);
                    }
                    else {
                        Toast.makeText(Login.this,
                                "Login error: " + task.getException().getMessage(),
                                Toast.LENGTH_SHORT).show();
                    }
                }
            });
        }
    }

    private void getUser(String authKey) {
        UserDAO userDAO = new UserDAO();
        userDAO.get().addListenerForSingleValueEvent(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                for (DataSnapshot data : snapshot.getChildren()) {
                    User user = data.getValue(User.class);
                    if (authKey.equals(user.getAuthKey())){
                        user.setUserKey(data.getKey());
                        userID = user.getUserKey();
                        accessLevel = user.getAccessLevel();
                        Intent intent = new Intent(Login.this, MainActivity.class);
                        intent.putExtra("userID", userID);
                        intent.putExtra("accessLevel", accessLevel);
                        startActivity(intent);
                        break;
                    }
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {
            Log.d("DB_ERROR", error.getMessage().toString());
            }
        });
    }
}