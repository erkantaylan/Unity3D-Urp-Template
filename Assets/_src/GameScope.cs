using System;
using MessagePipe;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Code
{
    public class GameScope : LifetimeScope
    {
        [SerializeField]
        private Inspectable inspectable;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.UseEntryPoints(Lifetime.Singleton, RegisterPresenters);
            RegisterMonos(builder);
            RegisterServices(builder);
            RegisterPipes(builder);
        }

        private static void RegisterServices(IContainerBuilder builder)
        {
            //builder.Register<TdGridService>(Lifetime.Singleton);
        }

        private static void RegisterPipes(IContainerBuilder builder)
        {
            MessagePipeOptions options = builder.RegisterMessagePipe();
            builder.RegisterBuildCallback(resolver => GlobalMessagePipe.SetProvider(resolver.AsServiceProvider()));
            //builder.RegisterMessageBroker<EnemyDestroyMessage>(options);
        }

        private void RegisterMonos(IContainerBuilder builder)
        {
            //builder.RegisterComponent<IMouseFollowerMono>(inspectable.mouseFollwer);
            //builder.RegisterComponent(inspectable.game);
        }

        private static void RegisterPresenters(EntryPointsBuilder builder)
        {
            //builder.Add<StepPresenter>();
        }

        [Serializable]
        private class Inspectable { }
    }
}