package io.github.karanina.triviaquiz;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.text.TextUtils;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.firebase.auth.AuthResult;
import com.google.firebase.auth.FirebaseAuth;

import io.github.karanina.triviaquiz.model.User;


public class Registration extends AppCompatActivity implements View.OnClickListener{

    TextView et_email, et_password, et_username;
    Button btn_register;
    FirebaseAuth firebaseAuth;
    String email, password, username, accessLevel, userID;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_registration);

        et_email = findViewById(R.id.et_emailAddress);
        et_password = findViewById(R.id.et_password);
        et_username = findViewById(R.id.et_username);
        btn_register = findViewById(R.id.btn_register);

        btn_register.setOnClickListener(this);

        firebaseAuth = FirebaseAuth.getInstance();

        Intent intent = getIntent();
        accessLevel = intent.getStringExtra("accessLevel");
        userID = intent.getStringExtra("userID");
    }

    @Override
    public void onClick(View view) {
        if (view.getId() == btn_register.getId()){
            createUser();
        }
    }

    private void createUser() {
        email = et_email.getText().toString();
        password = et_password.getText().toString();
        username = et_username.getText().toString();

        // if no email is passed in, show error message.
        if (TextUtils.isEmpty(email)){
            et_email.setError("Email address is required");
            et_email.requestFocus();
        }
        else if (TextUtils.isEmpty(username)){
            et_username.setError("Username is required");
            et_username.requestFocus();
        }
        else if (TextUtils.isEmpty(password)){
            et_password.setError("Password is required");
            et_password.requestFocus();
        }
        else {
            firebaseAuth.createUserWithEmailAndPassword(email, password)
                    .addOnCompleteListener(new OnCompleteListener<AuthResult>() {
                @Override
                public void onComplete(@NonNull Task<AuthResult> task) {
                    if (task.isSuccessful()){
                        Toast.makeText(Registration.this,
                                "Your account has been created.", Toast.LENGTH_SHORT).show();
                        String authKey = firebaseAuth.getUid();
                        User user = new User(email, username, authKey, accessLevel);
                        UserDAO userDAO = new UserDAO();
                        userDAO.add(user);
                        if (accessLevel.equals("Admin")){
                            Intent intent = new Intent();
                            intent.putExtra("userID", userID);
                            intent.putExtra("accessLevel", accessLevel);
                            intent.setClass(Registration.this, MainActivity.class);
                            startActivity(intent);
                        }
                        else {
                            startActivity(new Intent(Registration.this, Login.class));
                        }
                    }
                    else {
                        Toast.makeText(Registration.this,
                                "Registration error: " + task.getException().getMessage(),
                                Toast.LENGTH_SHORT).show();
                    }
                }
            });
        }
    }
}