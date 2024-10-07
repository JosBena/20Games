
import {Unity, useUnityContext} from "react-unity-webgl";
 const Game = () => {
    const { unityProvider } = useUnityContext({
        loaderUrl: "build/webgl/Game1.loader.js",
        dataUrl: "build/webgl/Game1.data.unityweb",
        frameworkUrl: "build/webgl/Game1.framework.js.unityweb",
        codeUrl: "build/webgl/Game1.wasm.unityweb",
      });
    
    return (
        <div>
            <Unity unityProvider={unityProvider} />
        </div>
    )
}

export default Game;
